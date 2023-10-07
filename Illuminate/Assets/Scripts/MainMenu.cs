/*****************************************************************************
// File Name : MainMenu.cs
// Author : Brian Hartwig
//
// Brief Description : Controls the Main Menu
*****************************************************************************/
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Security;
using System.Xml.Linq;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainScreen;
    [SerializeField] GameObject levelScreen;
    [SerializeField] GameObject creditScreen;
    [SerializeField] GameObject musicScreen;
    [SerializeField] GameObject howToPlayScreen;

    //Text variables for mute controls
    [SerializeField] TMP_Text sfxText;
    [SerializeField] TMP_Text musicText;

    // Audiomanager variable
    public AudioManager audioManager;

    public void Start()
    {
        //Find the audio manager and assign it
        audioManager = FindObjectOfType<AudioManager>();
    }

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

    //Opens Music Options
    public void OnButtonOpenMusicOptions()
    {
        //Check to see if the music is muted or not, then change the text accordingly
        //In case the music is muted in the pause menu, this ensures it will show up as muted in the main menu
        if (audioManager.isMusicplaying == true)
        {
            musicText.text = "Mute Music";
        }
        else
        {
            musicText.text = "Unmute Music";
        }
        if (audioManager.isSFXplaying == true)
        {
            sfxText.text = "Mute SFX";
        }
        else
        {
            sfxText.text = "Unmute SFX";
        }
        musicScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    //Closes Music Options
    public void OnButtonCloseMusicOptions()
    {
        musicScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void OnButtonSFX()
    {
        audioManager.playSFX(); // Tell audio manager to mute/unmute SFX  
        //Check to see if the SFX is muted or not, then change the text accordingly
        if (audioManager.isSFXplaying == true)
        {
            sfxText.text = "Mute SFX";
        }
        else
        {
            sfxText.text = "Unmute SFX";
        }

    }
    //Mute or unmute background music
    public void OnButtonMusic()
    {
        audioManager.playMusic(); // Tell audio manager to mute/unmute SFX
        //Check to see if the music is muted or not, then change the text accordingly
        if (audioManager.isMusicplaying == true)
        {
            musicText.text = "Mute Music";
        }
        else
        {
            musicText.text = "Unmute Music";
        }
    }

    //Closes Game
    public void OnButtonQuit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
