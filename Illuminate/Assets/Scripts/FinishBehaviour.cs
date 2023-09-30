/*****************************************************************************
// File Name : FinishBehaviour.cs
// Author : Sam Dwyer
//
// Brief Description : Is on the finish trigger and will call the finish level function
*****************************************************************************/
using UnityEngine;

public class FinishBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameController.gc.FinishLevel();
        }
    }
  
}
