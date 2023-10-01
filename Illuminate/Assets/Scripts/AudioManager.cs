/*****************************************************************************
// File Name : AudioManager.cs
// Author : Dylan Gazda
//
// Brief Description : Plays audio clips to generate sound effects 
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager am;
    public AudioClip jump;
    public AudioClip walk;
    public AudioClip death;

    // Start is called before the first frame update
    void Start()
    {   }

    // Update is called once per frame
    void Update()
    {   }

    private void Awake()
    { am = this; }

    public void playJump()
    {
        am.GetComponent<AudioSource>().PlayOneShot(jump);
    }

    public void playDeath()
    {
        am.GetComponent<AudioSource>().PlayOneShot(death);
    }

    public void playWalk(bool isMoving)
    {
        if (isMoving == true) {
            am.GetComponent<AudioSource>().clip = walk;
            am.GetComponent<AudioSource>().loop = true;
            am.GetComponent<AudioSource>().Play();
        }
        else
        {
            am.GetComponent<AudioSource>().loop = false;
            am.GetComponent<AudioSource>().Stop();
        }
    }

    /*public void playSound(AudioSource audioClip)
    {
        am.GetComponent<AudioSource>().clip = audioClip.clip;
        am.GetComponent<AudioSource>().Play();
    }*/
}
