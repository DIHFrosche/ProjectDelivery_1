using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmeny : MonoBehaviour
{

    public void Startgame(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Quit()
    {
    }
}
