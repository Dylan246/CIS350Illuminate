/*****************************************************************************
// File Name : PickUp.cs
// Author : Sam Dwyer
//
// Brief Description : Manages the triggers of a pick up object
*****************************************************************************/
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool followsMouse;

    // For when the player is in the pick up range
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.bounds.Intersects(gameObject.GetComponent<BoxCollider2D>().bounds))
        {
            if (collision.name == "Player" && collision.GetComponent<PlayerController>().HeldItem == null)
            {
                collision.GetComponent<PlayerController>().canPickUp = this;
            }
        }
    }

    // For when the player leaves the pick up range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerController>().canPickUp = null;
        }
    }
}
