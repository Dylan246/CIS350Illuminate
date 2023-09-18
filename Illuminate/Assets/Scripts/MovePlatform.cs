using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private GameObject movingPlatform;
    private float originalXPos;
    private bool goLeft;


    // Start is called before the first frame update
    void Start()
    {
        originalXPos = movingPlatform.transform.position.x; 
        goLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingPlatform.transform.position.x >= originalXPos + 3) //Moves 6 units in total 
        {
            goLeft = true;
        }
        if (movingPlatform.transform.position.x <= originalXPos - 3)
        {
            goLeft = false;
        }
        if (goLeft == true)
        {
            print("go left");
            //print(gameObject.transform.position.x);
            //print(originalXPos);
            movingPlatform.transform.Translate(new Vector3(-1f, 0) * Time.deltaTime, Space.World);
        }
        if (goLeft == false) // Then go right
        { 
            print("go right");
            //print(gameObject.transform.position.x);
            //print(originalXPos);
            movingPlatform.transform.Translate(new Vector3(1f, 0) * Time.deltaTime, Space.World);
        }
    }
}
