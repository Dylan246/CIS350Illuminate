/*****************************************************************************
// File Name : Holder.cs
// Author : Sam Dwyer
//
// Brief Description : Allows the holder to be able to hold a light source
*****************************************************************************/
using UnityEngine;

public class Holder : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the holder has a child ("light")
        if(gameObject.transform.childCount == 1)
        {
            gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector2(0, 0);

            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
        }
    }
}
