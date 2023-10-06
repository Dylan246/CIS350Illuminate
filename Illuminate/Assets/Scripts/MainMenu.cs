/*****************************************************************************
// File Name : MainMenu.cs
// Author : Brian Hartwig
//
// Brief Description : Controls the Main Menu
*****************************************************************************/
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainScreen;
    [SerializeField] GameObject levelScreen;
    [SerializeField] GameObject creditScreen;
    [SerializeField] GameObject howToPlayScreen;

    //Starts Game
    public void OnButtonStartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    //Starts Level 2
    public void OnButtonStartLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    //Starts Level 3
    public void OnButtonStartLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    //Starts Level 4
    public void OnButtonStartLevel4()
    {
        SceneManager.LoadScene("Level 4");
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

    // Opens How
    public void OnButtonOpenHowToPlay()
    {
        mainScreen.SetActive(false);
        howToPlayScreen.SetActive(true);
    }

    // Closes How
    public void OnButtonCloseHowToPlay()
    {
        mainScreen.SetActive(true);
        howToPlayScreen.SetActive(false);
    }

    //Closes Game
    public void OnButtonQuit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
