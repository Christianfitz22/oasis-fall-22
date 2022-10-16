using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        resetButton = GameObject.Find("ResetButton");
        resetButton.SetActive(false);
        moveButtonManager = GameObject.Find("MovementButtons").GetComponent<MoveButtonManager>();

        currentStats = new playerStats();
        statValues = GameObject.Find("StatValues").GetComponent<TMP_Text>();

        UpdateBoardPosition();
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
    }

    // should always be called at the end of each round
    public void ExecuteTurn()
    {
        UpdateBoardPosition();
        UpdateStatValues();
        ResetTurn();
    }

    public void UpdateBoardPosition()
    {
        MovePlayer();
        transform.position = new Vector3(boardX * cellSize + boardStart.x, boardStart.y - boardY * cellSize, 0f);
    }

    public void UpdateStatValues()
    {
        statValues.SetText(currentStats.getCurrentHealth() + " / 100\n" + currentStats.getATK() + "\n" + currentStats.getDEF() + "\n" + currentStats.getMovementSpeed());
    }

    // should be called whenever we need to reset a player's turn before the end of the round
    public void ResetTurn()
    {
        deltaX = 0;
        deltaY = 0;
        resetButton.SetActive(false);
        takenTurn = false;
        moveButtonManager.directionPressed();
    }

    // should be called whenever the player has finished setting their turn
    public void SetTurn()
    {
        resetButton.SetActive(true);
        takenTurn = true;
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

    public bool TurnTaken()
    {
        return takenTurn;
    }
}