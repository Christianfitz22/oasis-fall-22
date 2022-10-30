using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int boardHeight = Board.boardHeight;
    private int boardWidth = Board.boardWidth;
    private float cellSize = Board.cellSize;
    static Vector2 boardStart = Board.boardStart;

    [SerializeField]
    private int boardX = 0;
    [SerializeField]
    private int boardY = 0;

    [SerializeField]
    private int hitpoints;
    [SerializeField]
    private int attack;
    [SerializeField]
    private int defense;


    private playerStats currentStats;
    private opponentStrategy strat;

    private bool outOfPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        currentStats = new playerStats(hitpoints, attack, defense);

        //replace later
        strat = new randomMoveStrategy(this);

        UpdateBoardPosition();
    }

    public void UpdateBoardPosition()
    {
        transform.position = new Vector3(boardX * cellSize + boardStart.x, boardStart.y - boardY * cellSize, 0f);
    }

    public int getXPos()
    {
        return boardX;
    }

    public int getYPos()
    {
        return boardY;
    }

    public playerStats getStats()
    {
        return currentStats;
    }

    public void ExecuteTurn()
    {
        DeathCheck();
        if (!outOfPlay)
        {
            TakeTurn();
            UpdateBoardPosition();
        }
    }

    public void TakeTurn()
    {
        move toMove = strat.chooseMove();
        string m = toMove.getMove();
        if(m != null){  
            if(Equals(m, "up")){
                boardY = boardY - currentStats.getMovementSpeed();
            } else if(Equals(m, "down")){
                boardY = boardY + currentStats.getMovementSpeed();
            } else if(Equals(m, "right")){
                boardX = boardX + currentStats.getMovementSpeed();
            } else if(Equals(m, "left")){
                boardX = boardX - currentStats.getMovementSpeed();
            } else if(Equals(m, "card")){
                //add later, get target line
            }
        }
    }

    public void DeathCheck()
    {
        if (!currentStats.getIsAlive())
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            outOfPlay = true;
        }
    }

    public bool IsOutOfPlay()
    {
        return outOfPlay;
    }
}
