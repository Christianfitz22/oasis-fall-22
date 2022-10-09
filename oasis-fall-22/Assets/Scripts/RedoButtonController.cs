using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedoButtonController : MonoBehaviour
{
    private PlayerTest01 player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerTest01>();
    }

    public void Redo()
    {
        player.ResetTurn();
        gameObject.SetActive(false);
    }
}