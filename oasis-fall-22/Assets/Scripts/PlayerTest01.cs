using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PlayerTest01 : MonoBehaviour
{
    private int boardHeight = Board.boardHeight;
    private int boardWidth = Board.boardWidth;
    private float cellSize = Board.cellSize;
    private Vector2 boardStart = Board.boardStart;

    [SerializeField]
    private int boardX = 0;
    [SerializeField]
    private int boardY = 0;

    private int deltaX = 0;
    private int deltaY = 0;

    private bool takenTurn = false;

    private GameObject resetButton;
    private MoveButtonManager moveButtonManager;
    private playerStats currentStats;
    private TMP_Text statValues;

    private card attackExample;

    private deck playerDeck;
    private GameObject cardOne;
    private TMP_Text cardOneLabel;
    private GameObject cardTwo;
    private TMP_Text cardTwoLabel;
    private GameObject cardThree;
    private TMP_Text cardThreeLabel;

    private card[] playerHand;
    private int selectedIndex = 0;

    private playerStats queTarget = null;

    private GameObject effectButtons;

    // Start is called before the first frame update
    void Start()
    {
        resetButton = GameObject.Find("ResetButton");
        resetButton.SetActive(false);
        moveButtonManager = GameObject.Find("MovementButtons").GetComponent<MoveButtonManager>();

        currentStats = new playerStats();
        statValues = GameObject.Find("StatValues").GetComponent<TMP_Text>();

        UpdateBoardPosition();

        attackExample = new card("red", true);

        playerDeck = new deck();

        cardOne = GameObject.Find("CardOne");
        cardOneLabel = cardOne.transform.Find("CardOneLabel").gameObject.GetComponent<TMP_Text>();
        cardTwo = GameObject.Find("CardTwo");
        cardTwoLabel = cardTwo.transform.Find("CardTwoLabel").gameObject.GetComponent<TMP_Text>();
        cardThree = GameObject.Find("CardThree");
        cardThreeLabel = cardThree.transform.Find("CardThreeLabel").gameObject.GetComponent<TMP_Text>();

        effectButtons = GameObject.Find("EffectButtons");

        playerHand = new card[3];
        DrawCards();
        RenderCards();
        HideEffects();
        UpdateStatValues();
    }

    // Update is called once per frame
    void Update()
    {
        //debug movement
        if (Input.GetKeyDown("w") && boardY > 0)
        {
            boardY--;
            UpdateBoardPosition();
        }
        if (Input.GetKeyDown("s") && boardY < boardHeight - 1)
        {
            boardY++;
            UpdateBoardPosition();
        }
        if (Input.GetKeyDown("a") && boardX > 0)
        {
            boardX--;
            UpdateBoardPosition();
        }
        if (Input.GetKeyDown("d") && boardX < boardWidth - 1)
        {
            boardX++;
            UpdateBoardPosition();
        }
        if (Input.GetKeyDown("p"))
        {
            currentStats.addAffect(new statAffects(3, "atk", 2f));
        }
        if (Input.GetKeyDown("l"))
        {
            attackExample.playCard(currentStats, getTargetLine("w"));
        }
        //Debug.Log("HP: " + currentStats.getCurrentHealth());
    }

    // should always be called at the end of each round
    public void ExecuteTurn()
    {
        ExecuteCard();
        UpdateBoardPosition();
        UpdateStatValues();
        DrawCards();
        ResetTurn();
    }

    public void UpdateBoardPosition()
    {
        MovePlayer();
        transform.position = new Vector3(boardX * cellSize + boardStart.x, boardStart.y - boardY * cellSize, 0f);
    }

    public void UpdateStatValues()
    {
        statValues.SetText(currentStats.getCurrentHealth() + " / " + currentStats.getTotalHP() + "\n" + currentStats.getATK() + "\n" + currentStats.getDEF() + "\n" + currentStats.getMovementSpeed());
    }

    // should be called whenever we need to reset a player's turn before the end of the round
    public void ResetTurn()
    {
        deltaX = 0;
        deltaY = 0;
        queTarget = null;
        resetButton.SetActive(false);
        takenTurn = false;
        moveButtonManager.showMove();
        RenderCards();
        HideEffects();
    }

    // should be called whenever the player has finished setting their turn
    public void SetTurn()
    {
        resetButton.SetActive(true);
        takenTurn = true;
        HideCards();
    }

    // should be called whenever we need three new cards to be drawn and displayed for the player
    public void DrawCards()
    {
        playerHand = playerDeck.chooseCards().ToArray();
    }

    // should be called whenever all three cards need to be displayed
    public void RenderCards()
    {
        RenderCard(cardOne, cardOneLabel, 0);
        RenderCard(cardTwo, cardTwoLabel, 1);
        RenderCard(cardThree, cardThreeLabel, 2);
    }

    public void HideCards()
    {
        cardOne.SetActive(false);
        cardTwo.SetActive(false);
        cardThree.SetActive(false);
    }

    public void RenderCard(GameObject cardObj, TMP_Text cardLabel, int index)
    {
        cardObj.SetActive(true);
        cardLabel.SetText(playerHand[index].GetDesc());
        Debug.Log(playerHand[index]);
        Debug.Log(playerHand[index].GetDesc());
    }

    // called whenever the direction of the card to play has been decided
    public void PlayCard(string direction)
    {
        if (direction == "self")
        {
            queTarget = currentStats;

        }
        else
        {
            queTarget = getTargetLine(direction);
        }
        HideEffects();
        SetTurn();
    }

    public void ExecuteCard()
    {
        if (queTarget != null)
        {
            playerHand[selectedIndex].playCard(currentStats, queTarget);
            queTarget = null;
        }
    }

    public void SelectCard(int index)
    {
        selectedIndex = index;
        HideCards();
        ShowEffects();
        moveButtonManager.HideAll();
    }

    public void ShowEffects()
    {
        effectButtons.SetActive(true);
    }

    public void HideEffects()
    {
        effectButtons.SetActive(false);
    }


    public void MovePlayerX(int cx)
    {
        deltaX = cx;
        SetTurn();
        //UpdateBoardPosition();
    }

    public void MovePlayerY(int cy)
    {
        deltaY = cy;
        SetTurn();
        //UpdateBoardPosition();
    }

    // called to actually move the player on the board
    public void MovePlayer()
    {
        boardX = Mathf.Clamp(boardX + deltaX, 0, boardWidth - 1);
        boardY = Mathf.Clamp(boardY + deltaY, 0, boardHeight - 1);
        deltaX = 0;
        deltaY = 0;
    }

    public void MoveOpened()
    {
        HideCards();
    }

    public bool TurnTaken()
    {
        return takenTurn;
    }

    // finds the first enemy in a given direction
    // given a string direction "w" "a" "s" "d"
    // if finds none, returns null
    // otherwise, returns playerStats of the selected target
    public playerStats getTargetLine(string dir)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyController target = null;
        int closestDistance = 10000;
        foreach (GameObject enemy in enemies)
        {
            EnemyController enemyCon = enemy.GetComponent<EnemyController>();
            if (enemyCon.getStats().getIsAlive())
            {
                int yDistance = enemyCon.getYPos() - boardY;
                int xDistance = enemyCon.getXPos() - boardX;
                if (dir.Equals("w"))
                {
                    if (yDistance < 0 && xDistance == 0 && Math.Abs(yDistance) < closestDistance)
                    {
                        target = enemyCon;
                    }
                }
                else if (dir.Equals("s"))
                {
                    if (yDistance > 0 && xDistance == 0 && Math.Abs(yDistance) < closestDistance)
                    {
                        target = enemyCon;
                    }
                }
                else if (dir.Equals("d"))
                {
                    if (xDistance > 0 && yDistance == 0 && Math.Abs(xDistance) < closestDistance)
                    {
                        target = enemyCon;
                    }
                }
                else if (dir.Equals("a"))
                {
                    if (xDistance < 0 && yDistance == 0 && Math.Abs(xDistance) < closestDistance)
                    {
                        target = enemyCon;
                    }
                }
            }
        }
        if (target == null)
        {
            return null;
        }
        return target.getStats();
    }
}