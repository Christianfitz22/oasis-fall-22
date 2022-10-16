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

    private playerStats currentStats;

    // Start is called before the first frame update
    void Start()
    {
        currentStats = new playerStats();

        UpdateBoardPosition();
    }

    public void UpdateBoardPosition()
    {
        transform.position = new Vector3(boardX * cellSize + boardStart.x, boardStart.y - boardY * cellSize, 0f);
    }
}
