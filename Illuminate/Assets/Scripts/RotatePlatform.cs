/*****************************************************************************
// File Name : RotatePlatform.cs
// Author : Dylan Gazda
//
// Brief Description : Manages the rotation of certain platforms
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private GameObject rotatingPlatform;
    public int rotationalSpeed; //Defined in each object so that it can vary (baseline value 25f)

    // Update is called once per frame
    void Update()
    {
       //Simple for now, just rotate at a constant speed 
       rotatingPlatform.transform.Rotate(new Vector3(0, 0, rotationalSpeed) * Time.deltaTime, Space.World);
    }
}
