using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSource : MonoBehaviour
{
    public enum SourceType { Cone, Sphere };
    public SourceType LightType;

    private float radius;
    // Start is called before the first frame update
    void Start()
    {
        if(LightType == SourceType.Sphere)
        {
            radius = GetComponent<Light2D>().pointLightOuterRadius;
            print(radius);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        var rayDirection = GameObject.Find("Player").transform.position - transform.position;

        
    }
}
