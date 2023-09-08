using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;


    // actions that will be done by the player
    private InputAction move;
    private InputAction jump;
    private InputAction death;

    // variable to check if player is moving or not
    private bool isPlayerMoving;
    // reference for this boolean:
    [SerializeField] private GameObject player;

    // variable for how fast the player will move
    [SerializeField] private float playerSpeed;

    // direction for player
    private float moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
