using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemeny : MonoBehaviour {


    public bool Gameispaused = false;
    public GameObject pausemenuUI;

	// Use this for initialization
	void Start ()
    {
        Resume();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(Gameispaused == false)
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        Gameispaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }
    public void Pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        Gameispaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void Continue()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void mainmenu()
    {
        SceneManager.LoadScene(1);
    }
    public void restart()
    {
        SceneManager.LoadScene(4);
    }
}
