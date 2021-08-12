using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// function for when play is pressed
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /// <summary>
    /// function for when quit is pressed
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    /// <summary>
    /// function for when main menu is pressed
    /// </summary>
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}