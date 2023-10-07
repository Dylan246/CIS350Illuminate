/*****************************************************************************
// File Name : LightSwitch.cs
// Author : Sam Dwyer
//
// Brief Description : Handles a light sources' light status
*****************************************************************************/
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public LightSource lightSource;

    // Audiomanager variable
    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioManager = FindObjectOfType<AudioManager>();
            audioManager.playSwitch(); //Play switch click sound
            lightSource.FlickerLight();
        }
    }
}
