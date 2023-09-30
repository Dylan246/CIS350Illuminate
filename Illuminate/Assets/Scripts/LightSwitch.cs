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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            lightSource.FlickerLight();
        }
    }
}
