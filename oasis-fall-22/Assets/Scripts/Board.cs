using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static int boardHeight = 10;
    public static int boardWidth = 8;
    public static float cellSize = 1f;
    public static Vector2 boardStart = new Vector2(-3.5f, 4.5f);

    public static List<GameObject> allPieces = new List<GameObject>();

    void Start()
    {
        //allPieces = new List<GameObject>();
        //Debug.Log("all pieces cleared");
    }

    public static bool SpaceOccupied(float tx, float ty)
    {
        foreach (GameObject piece in allPieces)
        {
            EnemyController potCon = piece.GetComponent<EnemyController>();
            PlayerTest01 potPlayer = piece.GetComponent<PlayerTest01>();

            if ((potPlayer != null) || ((potCon != null) && potCon.getStats().getIsAlive()))
            {
                float sx = piece.transform.position.x;
                float sy = piece.transform.position.y;
                float bsx = (sx - boardStart.x) / cellSize;
                float bsy = (boardStart.y - sy) / cellSize;
                // boardX * cellSize + boardStart.x
                if (Mathf.Approximately(bsx, tx) && Mathf.Approximately(bsy, ty))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static void AddPiece(GameObject piece)
    {
        allPieces.Add(piece);
        Debug.Log("piece added");
    }

    public static void ClearBoard()
    {
        allPieces = new List<GameObject>();
        Debug.Log("board cleared");
    }

    public static bool OnlyPlayer()
    {
        int alive = 0;
        bool playerAlive = false;

        foreach (GameObject piece in allPieces)
        {
            EnemyController potCon = piece.GetComponent<EnemyController>();
            PlayerTest01 potPlayer = piece.GetComponent<PlayerTest01>();

            playerStats stats = null;

            if (potCon != null)
            {
                stats = potCon.getStats();
            }
            else
            {
                stats = potPlayer.GetStats();
                playerAlive = true;
            }

            if (stats != null && stats.getIsAlive())
            {
                alive++;
            }
        }

        if (alive == 1 && playerAlive)
        {
            return true;
        }
        return false;
    }
}
