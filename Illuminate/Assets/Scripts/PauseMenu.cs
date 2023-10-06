/*****************************************************************************
// File Name : PauseMenu.cs
// Author : Dylan Gazda
//
// Brief Description : Controls the Pause Menu canvas object
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class PauseMenu : MonoBehaviour
{
    //Get our UI elements 
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject tutorialScreen;

    //How to play button pressed (shows tutorial)
    public void OnButtonOpenTutorial()
    {
        tutorialScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    //Tutorial return button pressed
    public void OnButtonCloseTutorial()
    {
        tutorialScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    //Restart level button pressed
    public void OnButtonRestart()
    {
        Time.timeScale = 1; //Or else time will still be frozen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Resume button pressed
    public void OnButtonResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1; //In case you're in the pause menu and restart game
    }

    //Return to main menu button pressed
    public void OnButtonQuit()
    {
        Time.timeScale = 1; //Or else time will still be frozen
        SceneManager.LoadScene(0); //Take back to main menu
    }

}
