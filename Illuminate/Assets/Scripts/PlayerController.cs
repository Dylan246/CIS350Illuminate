using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    // actions that will be done by the player
    private InputAction move;
    private InputAction jump;

    // variable to check if player is moving or not
    private bool isPlayerMoving;

    // variable for how fast the player will move
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;

    // direction for player
    private float moveDirection;

    private bool isJumping;

    public bool isInLight;

    // temporary placeholder variable for point of player death
    // upon falling (don't know yet what's the exact point of death)
    private int placeHoldPointOfDeath;

    // Start is called before the first frame update
    void Start()
    {
        EnableInputs();

        isPlayerMoving = false;
        isJumping = false;
    }

    void Update()
    {
        // checks to see if player has fallen to their death
        if(gameObject.transform.position.y < placeHoldPointOfDeath)
        {
            RespawnPlayer();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isPlayerMoving)
        {
            moveDirection = move.ReadValue<float>();
            GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed * moveDirection, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }

        if(isJumping)
        {
            isJumping = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }

        print(isInLight);
    }

    // function that enables action inputs to be read
    private void EnableInputs()
    {
        // Activating action map
        playerInput.currentActionMap.Enable();

        // reading in inputs
        move = playerInput.currentActionMap.FindAction("Move");
        jump = playerInput.currentActionMap.FindAction("Jump");

        move.started += Move_started;
        move.canceled += Move_canceled;
        jump.started += Jump_started;
    }

    private void Jump_started(InputAction.CallbackContext obj)
    {
        isJumping = true;
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        isPlayerMoving = false;
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        isPlayerMoving = true;
    }

    public void OnDestroy()
    {
        move.started -= Move_started;
        move.canceled -= Move_canceled;
        jump.started -= Jump_started;
    }

    // method to respawn player upon falling to death
    private void RespawnPlayer()
    {
        // player will be reset to a certain position on screen
        // (don't know where yet)

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        isPlayerMoving = false;
    }
}

