using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSource : MonoBehaviour
{
    public enum SourceType { Cone, Sphere };
    public SourceType LightType;
    public bool doesItFlicker;
    private bool currentlyOn;

    public bool startTurnedOff;

    private GameObject player;


    private float radius;

    

    public bool playerIsInLight = false;
    // Start is called before the first frame update
    void Start()
    {
        currentlyOn = true;
        if(startTurnedOff)
        {
            FlickerLight();
        }
       
        player = FindObjectOfType<PlayerController>().gameObject;
        if(LightType == SourceType.Sphere || LightType == SourceType.Cone)
        {
            radius = GetComponent<Light2D>().pointLightOuterRadius;
        }

        if(doesItFlicker)
        {
            InvokeRepeating(nameof(FlickerLight), 1f, 3f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(LightType == SourceType.Sphere)
        {
            playerIsInLight = IsSphereDetectingPlayer();
        }
    }

    

    bool IsSphereDetectingPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
            player.transform.position - transform.position, radius, ~LayerMask.GetMask("Light"));

        Debug.DrawRay(transform.position,
            player.transform.position - transform.position, Color.red);

        if(hit == true)
        {
            if(hit.collider.tag == "Player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,
            player.transform.position - transform.position, radius, ~LayerMask.GetMask("Light"));

            Debug.DrawRay(transform.position,
                    player.transform.position - transform.position, Color.red);

            if (hit == true)
            {
                if (hit.collider.tag == "Player")
                {
                    playerIsInLight = true;
                }
                else
                {
                    playerIsInLight = false;
                }
            }
            else
            {
                playerIsInLight = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerIsInLight = false;
        }
    }

   

    public void FlickerLight()
    {
        currentlyOn = !currentlyOn;
        gameObject.GetComponent<Light2D>().enabled = currentlyOn;
        gameObject.GetComponent<PolygonCollider2D>().enabled = currentlyOn;
    }

    
}
