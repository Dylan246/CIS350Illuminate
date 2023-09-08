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
        EnableInputs();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerMoving)
        {
            moveDirection = move.ReadValue<float>();
        }
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
        
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        isPlayerMoving = false;
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        isPlayerMoving = true;
    }
}
