using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static bool playerWon = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameplayTest01");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ShowInstructions()
    {
        SceneManager.LoadScene("InstructionsScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void AbandonGame()
    {
        Board.ClearBoard();
        SceneManager.LoadScene("TitleScreen");
    }

    public static void EndGameLose()
    {
        playerWon = false;
        SceneManager.LoadScene("GameOverScreen");
    }

    public static void EndGameWin()
    {
        playerWon = true;
        SceneManager.LoadScene("GameOverScreen");
    }
}
