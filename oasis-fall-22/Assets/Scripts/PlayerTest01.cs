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

    // Start is called before the first frame update
    void Start()
    {
        updateBoardPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w") && boardY > 0)
        {
            boardY--;
            updateBoardPosition();
        }
        if (Input.GetKeyDown("s") && boardY < boardHeight-1)
        {
            boardY++;
            updateBoardPosition();
        }
        if (Input.GetKeyDown("a") && boardX > 0)
        {
            boardX--;
            updateBoardPosition();
        }
        if (Input.GetKeyDown("d") && boardX < boardWidth-1)
        {
            boardX++;
            updateBoardPosition();
        }
    }

    public void updateBoardPosition()
    {
        transform.position = new Vector3(boardX * cellSize + boardStart.x, boardStart.y - boardY * cellSize, 0f);
    }
}
