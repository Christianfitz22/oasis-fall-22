using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

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
        currentStats = new playerStats(hitpoints, attack, defense, false); //TODO: fix for spawning

        //TODO: replace later
        strat = new randomMoveStrategy(this);

        UpdateBoardPosition();
        Board.AddPiece(gameObject);
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


    /**
    Finds the first object in a given direction "up", "down", "left", or "right".
    Returns null if none could be found, otherwise returns the playerStats.
    */
    public playerStats getTargetLine(string dir)
    {
        //TODO: add player to enemies[]
        //TODO: Maybe change it so enemies or allies?
        Component target = null;
        int closestDistance = 10000;
        foreach (GameObject enemy in Board.allPieces)
        {
            EnemyController subConEnemy = enemy.GetComponent<EnemyController>();
            PlayerTest01 subConPlayer = enemy.GetComponent<PlayerTest01>();

            if (subConEnemy != null)
            {
                if (subConEnemy.getStats().getIsAlive())
                {
                    int yDistance = subConEnemy.getYPos() - boardY;
                    int xDistance = subConEnemy.getXPos() - boardX;
                    if (dir.Equals("up"))
                    {
                        if (yDistance < 0 && xDistance == 0 && Math.Abs(yDistance) < closestDistance)
                        {
                            target = subConEnemy;
                        }
                    }
                    else if (dir.Equals("down"))
                    {
                        if (yDistance > 0 && xDistance == 0 && Math.Abs(yDistance) < closestDistance)
                        {
                            target = subConEnemy;
                        }
                    }
                    else if (dir.Equals("right"))
                    {
                        if (xDistance > 0 && yDistance == 0 && Math.Abs(xDistance) < closestDistance)
                        {
                            target = subConEnemy;
                        }
                    }
                    else if (dir.Equals("left"))
                    {
                        if (xDistance < 0 && yDistance == 0 && Math.Abs(xDistance) < closestDistance)
                        {
                            target = subConEnemy;
                        }
                    }
                }
            }
            else if (subConPlayer != null)
            {
                if (subConPlayer.GetStats().getIsAlive())
                {
                    int yDistance = subConPlayer.GetYPos() - boardY;
                    int xDistance = subConPlayer.GetXPos() - boardX;
                    if (dir.Equals("up"))
                    {
                        if (yDistance < 0 && xDistance == 0 && Math.Abs(yDistance) < closestDistance)
                        {
                            target = subConPlayer;
                        }
                    }
                    else if (dir.Equals("down"))
                    {
                        if (yDistance > 0 && xDistance == 0 && Math.Abs(yDistance) < closestDistance)
                        {
                            target = subConPlayer;
                        }
                    }
                    else if (dir.Equals("right"))
                    {
                        if (xDistance > 0 && yDistance == 0 && Math.Abs(xDistance) < closestDistance)
                        {
                            target = subConPlayer;
                        }
                    }
                    else if (dir.Equals("left"))
                    {
                        if (xDistance < 0 && yDistance == 0 && Math.Abs(xDistance) < closestDistance)
                        {
                            target = subConPlayer;
                        }
                    }
                }
            }
        }

        EnemyController sConEnemy = target.GetComponent<EnemyController>();
        PlayerTest01 sConPlayer = target.GetComponent<PlayerTest01>();

        if (sConEnemy != null)
        {
            return sConEnemy.getStats();
        }
        else
        {
            return sConPlayer.GetStats();
        }
    }
}
