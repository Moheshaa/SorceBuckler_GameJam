using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene when the "Play" button is pressed
        SceneManager.LoadScene("VideoScene");
    }

    public void PlayGameScene()
    {
        // Load the game scene when the "Play" button is pressed
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        // Load the game scene when the "Play" button is pressed
        SceneManager.LoadScene("MainMenu");
    }

    public void Credit()
    {
        // Load the game scene when the "Play" button is pressed
        SceneManager.LoadScene("CreditScene");
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}
