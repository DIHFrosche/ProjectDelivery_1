﻿using System.Collections;
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Gameispaused == false)
            {
                Pause();
            }
            else
                Resume();
        }
    }
    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        Gameispaused = false;
        ShowCursor.SetCursorLock(true);


    }
    public void Pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        Gameispaused = true;
        ShowCursor.SetCursorLock(false);


    }

    public void mainmenu()
    {
        SceneManager.LoadScene(1);
    }
    public void restart()
    {
        SceneManager.LoadScene(4);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
