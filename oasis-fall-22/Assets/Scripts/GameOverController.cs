using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public TMP_Text endText;

    // Start is called before the first frame update
    void Start()
    {
        if (MainMenuController.playerWon)
        {
            endText.SetText("You win!");
        }
        else
        {
            endText.SetText("You lose.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
