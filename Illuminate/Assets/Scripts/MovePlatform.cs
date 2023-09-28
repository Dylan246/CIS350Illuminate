using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private GameObject movingPlatform;
    public bool MoveUpDown;
    private float originalXPos;
    private bool goLeft;
    public float distance; //Distance will be defined in each object so that it can be varied (baseline value 3)
    public int speed; //Also defined in each object so it can be varied (baseline value 1f)


    // Start is called before the first frame update
    void Start()
    {
        if(!MoveUpDown)
        {
            originalXPos = movingPlatform.transform.position.x; //Save the original position
        }
        else
        {
            originalXPos = movingPlatform.transform.position.y; //Save the original position
        }
        goLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!MoveUpDown)
        {
            if (movingPlatform.transform.position.x >= originalXPos + distance) //Moves distance * 2 units in total 
            {
                goLeft = true;
            }
            if (movingPlatform.transform.position.x <= originalXPos - distance)
            {
                goLeft = false;
            }
            if (goLeft == true)
            {
                //print(gameObject.transform.position.x);
                //print(originalXPos);
                movingPlatform.transform.Translate(new Vector3(-speed, 0) * Time.deltaTime, Space.World);
            }
            if (goLeft == false) // Then go right
            {
                //print(gameObject.transform.position.x);
                //print(originalXPos);
                movingPlatform.transform.Translate(new Vector3(speed, 0) * Time.deltaTime, Space.World);
            }
        }
        else
        {
            if (movingPlatform.transform.position.y >= originalXPos + distance) //Moves distance * 2 units in total 
            {
                goLeft = true;
            }
            if (movingPlatform.transform.position.y <= originalXPos - distance)
            {
                goLeft = false;
            }
            if (goLeft == true)
            {
                //print(gameObject.transform.position.x);
                //print(originalXPos);
                movingPlatform.transform.Translate(new Vector3(0, -speed) * Time.deltaTime, Space.World);
            }
            if (goLeft == false) // Then go right
            {
                //print(gameObject.transform.position.x);
                //print(originalXPos);
                movingPlatform.transform.Translate(new Vector3(0, speed) * Time.deltaTime, Space.World);
            }
        }
        
    }
}
