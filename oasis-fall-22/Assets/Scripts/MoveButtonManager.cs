using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonManager : MonoBehaviour
{
    private GameObject moveButton;
    private GameObject directionButtons;
    private PlayerTest01 player;

    // Start is called before the first frame update
    void Start()
    {
        moveButton = transform.Find("MoveButton").gameObject;
        directionButtons = transform.Find("DirectionButtons").gameObject;
        directionButtons.SetActive(false);
        player = GameObject.Find("Player").GetComponent<PlayerTest01>();
    }

    public void movePressed()
    {
        if (!player.TurnTaken())
        {
            moveButton.SetActive(false);
            directionButtons.SetActive(true);
        }
    }

    public void directionPressed()
    {
        if (!player.TurnTaken())
        {
            directionButtons.SetActive(false);
            moveButton.SetActive(true);
        }
    }
}
