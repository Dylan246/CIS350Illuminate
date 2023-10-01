/*****************************************************************************
// File Name : MainMenu.cs
// Author : Brian Hartwig
//
// Brief Description : Controls the Main Menu
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainScreen;
    [SerializeField] GameObject levelScreen;
    [SerializeField] GameObject creditScreen;
    
    //Starts Game
    public void OnButtonStartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    //Starts Game
    public void OnButtonStartLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    //Starts Game
    public void OnButtonStartLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    //Starts Game
    public void OnButtonStartLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
    //Starts Game
    public void OnButtonStartLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }


    //Opens Credits
    public void OnButtonOpenCredits()
    {
        creditScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    //Closes Credits
    public void OnButtonCloseCredits()
    {
        creditScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    //Opens Levels
    public void OnButtonOpenLevels()
    {
        levelScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    //Closes Levels
    public void OnButtonCloseLevels()
    {
        levelScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    //Closes Game
    public void OnButtonQuit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
