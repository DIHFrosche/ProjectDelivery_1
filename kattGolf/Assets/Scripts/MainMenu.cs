using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int gameScene;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
