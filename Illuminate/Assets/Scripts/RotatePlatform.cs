using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private GameObject rotatingPlatform;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       //Simple for now
       rotatingPlatform.transform.Rotate(new Vector3(0, 0, 25f) * Time.deltaTime, Space.World);
    }
}
