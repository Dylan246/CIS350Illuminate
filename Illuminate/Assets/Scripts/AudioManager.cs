/*****************************************************************************
// File Name : AudioManager.cs
// Author : Dylan Gazda
//
// Brief Description : Plays background music and audio clips for sound effects
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    //Audio variables
    public static AudioManager am;
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource walk;
    [SerializeField] private AudioSource click;

    //These bools are also accessed by the menu scripts
    public bool isSFXplaying;
    public bool isMusicplaying;

    private void Awake()
    {
        isSFXplaying = true;
        isMusicplaying = true;
        //Deals with keeping the am alive between scenes, otherwise it resets the audio clips and their volumes
        if (am == null)
        {
            am = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Plays jump sound when player jumps
    public void playJump()
    {
        am.jump.PlayOneShot(jump.clip);
    }

    public void playSwitch()
    {
        am.click.PlayOneShot(click.clip);
    }

    //If moving, play walking clip, if not, stop clip
    public void playWalk(bool isMoving)
    {
        if (isMoving == true) { 
            am.walk.Play();
        }
        else
        {
            am.walk.Stop();
        }
    }

    //Mute or unmute background music
    public void playMusic()
    {
        if (isMusicplaying == true)
        {
            isMusicplaying = false;
            am.bgMusic.volume = 0;
        }
        else
        {
            isMusicplaying = true;
            am.bgMusic.volume = 0.3f; //Unmute and set to default volume
        }
    }
    //Mute or unmute SFX
    public void playSFX()
    {
        if (isSFXplaying == true)
        {
            isSFXplaying = false;
            am.jump.volume = 0;
            am.walk.volume = 0;
            am.click.volume = 0;
        }
        else //Unmute SFX and set volume back to defaults
        {
            isSFXplaying = true;
            am.jump.volume = 0.4f;
            am.walk.volume = 1;
            am.click.volume = 0.7f;
        }
    }

}
