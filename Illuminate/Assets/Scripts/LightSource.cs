using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSource : MonoBehaviour
{
    public enum SourceType { Cone, Sphere };
    public SourceType LightType;

    private GameObject player;

    private float radius;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        if(LightType == SourceType.Sphere || LightType == SourceType.Cone)
        {
            radius = GetComponent<Light2D>().pointLightOuterRadius;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(LightType == SourceType.Sphere)
        {
            print(IsSphereDetectingPlayer());
        }
        else if(LightType == SourceType.Cone)
        {
            print(IsConeDetectingPlayer());
        }
    }

    bool IsSphereDetectingPlayer()
    {
        try
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,
            player.transform.position - transform.position, radius);
            Debug.DrawRay(transform.position,
                player.transform.position - transform.position, Color.red);

            if(hit.collider.tag == "Player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    bool IsConeDetectingPlayer()
    {
        try
        {
            Debug.DrawRay(transform.position,
                Vector3.forward + new Vector3(radius, 0, 0), Color.red);
            Debug.DrawRay(transform.position,
                Vector3.forward + new Vector3(radius, -2.2f, 0), Color.red);
            Debug.DrawRay(transform.position,
                Vector3.forward + new Vector3(radius, 2.2f, 0), Color.red);

            RaycastHit2D hit = Physics2D.Raycast(transform.position,
            Vector3.forward + new Vector3(radius, 0, 0), radius);
            if (hit.collider.tag == "Player")
            {
                return true;
            }
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position,
            Vector3.forward + new Vector3(radius, -2.2f, 0), radius);
            if (hit2.collider.tag == "Player")
            {
                return true;
            }
            RaycastHit2D hit3 = Physics2D.Raycast(transform.position,
            Vector3.forward + new Vector3(radius, 2.2f, 0), radius);
            if (hit3.collider.tag == "Player")
            {
                return true;
            }

            return false;
        }
        catch
        {
            print("fuck");
            return false;
        }
    }
}
