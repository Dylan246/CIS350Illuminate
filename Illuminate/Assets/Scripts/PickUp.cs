using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool followsMouse;

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerController>().canPickUp = null;
        }
    }
}
