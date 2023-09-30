/*****************************************************************************
// File Name : LightSource.cs
// Author : Sam Dwyer
//
// Brief Description : Makes sure the camera has a max y level
*****************************************************************************/
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y != 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
        }
    }
}
