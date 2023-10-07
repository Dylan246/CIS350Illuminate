/*****************************************************************************
// File Name : PauseMenu.cs
// Author : Dylan Gazda
//
// Brief Description : Controls the Pause Menu canvas object
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    //Get our UI elements 
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject tutorialScreen;
    [SerializeField] GameObject musicScreen;

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

    //Music options button pressed
    public void OnButtonOpenMusicOptions()
    {
        //Check to see if the music is muted or not, then change the text accordingly
        //In case the music is muted in the main menu, this ensures it will show up as muted in the pause menu
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
        pauseScreen.SetActive(false);
    }

    //Tutorial return button pressed
    public void OnButtonCloseMusicOptions()
    {
        musicScreen.SetActive(false);
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

    //Mute or unmute SFX
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

    //Change music/sfx button text if the music is muted/unmuted
    public void changeButtonText()
    {

    }

}
