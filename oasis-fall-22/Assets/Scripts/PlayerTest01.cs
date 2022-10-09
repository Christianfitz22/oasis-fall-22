using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest01 : MonoBehaviour
{
    static int boardHeight = 10;
    static int boardWidth = 8;
    static float cellSize = 1f;
    static Vector2 boardStart = new Vector2(-3.5f, 4.5f);

    [SerializeField]
    private int boardX = 0;
    [SerializeField]
    private int boardY = 0;

    private int deltaX = 0;
    private int deltaY = 0;

    private bool takenTurn = false;

    private GameObject resetButton;
    private MoveButtonManager moveButtonManager;

    // Start is called before the first frame update
    void Start()
    {
        resetButton = GameObject.Find("ResetButton");
        resetButton.SetActive(false);
        moveButtonManager = GameObject.Find("MovementButtons").GetComponent<MoveButtonManager>();

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
        ResetTurn();
    }

    public void UpdateBoardPosition()
    {
        MovePlayer();
        transform.position = new Vector3(boardX * cellSize + boardStart.x, boardStart.y - boardY * cellSize, 0f);
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

    // shoud be called whenever the player has finished setting their turn
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