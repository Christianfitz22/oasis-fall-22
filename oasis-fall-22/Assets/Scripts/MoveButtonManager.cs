using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonManager : MonoBehaviour
{
    private GameObject moveButton;
    private GameObject directionButtons;

    // Start is called before the first frame update
    void Start()
    {
        moveButton = transform.Find("MoveButton").gameObject;
        directionButtons = transform.Find("DirectionButtons").gameObject;
        directionButtons.SetActive(false);
    }

    public void movePressed()
    {
        moveButton.SetActive(false);
        directionButtons.SetActive(true);
    }

    public void directionPressed()
    {
        directionButtons.SetActive(false);
        moveButton.SetActive(true);
    }
}
