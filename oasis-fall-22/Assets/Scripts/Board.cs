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

    public static bool SpaceOccupied(float tx, float ty)
    {
        foreach (GameObject piece in allPieces)
        {
            Debug.Log(piece);
            float sx = piece.transform.position.x;
            float sy = piece.transform.position.y;
            float bsx = (sx - boardStart.x) / cellSize;
            float bsy = (boardStart.y - sy) / cellSize;
            // boardX * cellSize + boardStart.x
            Debug.Log("Piece coordinates: " + bsx + " " + bsy + "\nTarget coordinate: " + tx + " " + ty);
            if (Mathf.Approximately(bsx, tx) && Mathf.Approximately(bsy, ty))
            {
                return true;
            }
        }
        return false;
    }

    public static void AddPiece(GameObject piece)
    {
        allPieces.Add(piece);
    }
}
