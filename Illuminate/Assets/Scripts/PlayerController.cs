/*****************************************************************************
// File Name : PlayerController.cs
// Author : Sam Dwyer
//
// Brief Description : Holds the player inputs, the various triggers that the player can interact with,
//                     player movement, player interactions with lights, and death
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    // Actions that will be done by the player
    private InputAction move;
    private InputAction jump;
    private InputAction equip;
    private InputAction dequip;
    private InputAction restart;
    private InputAction quit;

    // Variable to check if player is moving or not
    private bool isPlayerMoving;

    // Variable for how fast the player will move
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;
    private bool canJump;

    // Direction for player
    private float moveDirection;

    // Bools for player actions
    private bool isJumping;
    private bool isEquiping;
    private bool isDequiping;

    // Hanger variables
    private bool canPutOnHanger;
    public GameObject hanger;

    // Bool determining if the player is in light
    public bool isInLight;

    // Pick Up variables
    public PickUp canPickUp;
    public PickUp HeldItem;

    // Animation variables
    public Holder playerHolder;
    private Animator stickman;

    // Grace period in darkness
    [SerializeField] [Range(0, 1f)] private float timeTillDead = 1f;

    // The light sources in the scene
    [SerializeField] private LightSource[] sourcesInScene;

    // Start is called before the first frame update
    void Start()
    {
        // Turn on all inputs
        EnableInputs();

        sourcesInScene = GameObject.FindObjectsOfType<LightSource>();

        /*stickman = GetComponent<Animator>();
        stickman.SetBool("move_player", isPlayerMoving);
        stickman.SetBool("jump_player", isJumping);*/

        isPlayerMoving = false;
        isJumping = false;
    }

    /// <summary>
    /// Trigger for when the player triggers a hanger or death barrier
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PointOfDeath")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(collision.tag == "Hanger")
        {
            canPutOnHanger = true;
            hanger = collision.gameObject;
        }
    }

    /// <summary>
    /// Trigger for when the player leaves a hanger
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Hanger")
        {
            canPutOnHanger = false;
            hanger = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Detection for when a player is on ground (resets jump)
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
            Vector2.down, 1.1f, LayerMask.GetMask("Platform"));

        Debug.DrawRay(transform.position,
                Vector2.down, Color.magenta);

        if(hit == true)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        // Move player
        if (isPlayerMoving)
        {
            moveDirection = move.ReadValue<float>();
            GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed * moveDirection, GetComponent<Rigidbody2D>().velocity.y);  
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }

        // Jump player
        if(isJumping && canJump)
        {
            canJump = false;
            isJumping = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }

        // Player presses "E"
        if(isEquiping)
        {
            isEquiping = false;

            // Taking a light off of a hanger (player cannot be holding a light)
            if(HeldItem == null && canPutOnHanger && hanger.GetComponent<Hanger>().holdingLight != null)
            {
                HeldItem = hanger.GetComponent<Hanger>().holdingLight;
                hanger.GetComponent<Hanger>().holdingLight = null;
                HeldItem.gameObject.transform.SetParent(playerHolder.gameObject.transform);
                HeldItem.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                HeldItem.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                HeldItem.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            // Putting a light on a hanger (player has to be holding a light and hanger cannot have a light already on)
            else if(HeldItem != null && canPutOnHanger && hanger.GetComponent<Hanger>().holdingLight == null)
            {
                HeldItem.gameObject.transform.SetParent(hanger.transform);
                HeldItem.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                HeldItem.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                HeldItem.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                hanger.GetComponent<Hanger>().holdingLight = HeldItem;
                HeldItem = null;
            }
            // Picking light off ground
            else if(canPickUp != null)
            {
                HeldItem = canPickUp;
                canPickUp = null;
                HeldItem.gameObject.transform.SetParent(playerHolder.gameObject.transform);
                HeldItem.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                HeldItem.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                HeldItem.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                HeldItem.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                HeldItem.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                HeldItem.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }

        // Player presses "Q"
        if(isDequiping)
        {
            isDequiping = false;
            if(HeldItem != null)
            {
                HeldItem.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                HeldItem.gameObject.transform.SetParent(null);
                HeldItem.gameObject.GetComponent<CircleCollider2D>().enabled = true;
                HeldItem.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                canPickUp = HeldItem;
                HeldItem = null;
                
            }
        }

        CheckIfInLight();

        // Handles death of player
        if(isInLight && timeTillDead <= 1f)
        {
            timeTillDead += Time.deltaTime;
        }
        else
        {
            timeTillDead -= Time.deltaTime;
        }

        if(timeTillDead <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // function that enables action inputs to be read
    private void EnableInputs()
    {
        // Activating action map
        playerInput.currentActionMap.Enable();

        // Reading in inputs
        move = playerInput.currentActionMap.FindAction("Move");
        jump = playerInput.currentActionMap.FindAction("Jump");
        equip = playerInput.currentActionMap.FindAction("Equip");
        dequip = playerInput.currentActionMap.FindAction("Dequip");
        quit = playerInput.currentActionMap.FindAction("Quit");
        restart = playerInput.currentActionMap.FindAction("Restart");

        move.started += Move_started;
        move.canceled += Move_canceled;
        jump.started += Jump_started;
        equip.started += Equip_started;
        dequip.started += Dequip_started;
        quit.started += Quit_started;
        restart.started += Restart_started;
    }

    private void Jump_started(InputAction.CallbackContext obj)
    {
        isJumping = true;
    }

    private void Restart_started(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Quit_started(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

    private void Equip_started(InputAction.CallbackContext obj)
    {
        isEquiping = true;
    }

    private void Dequip_started(InputAction.CallbackContext obj)
    {
        isDequiping = true;
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
        equip.started -= Equip_started;
        dequip.started -= Dequip_started;
        quit.started -= Quit_started;
        restart.started -= Restart_started;
    }

    /// <summary>
    /// Goes through light sources and determines if the player is in light
    /// </summary>
    private void CheckIfInLight()
    {
        bool output = false;

        for(int i = 0; i < sourcesInScene.Length; ++i)
        {
            if(sourcesInScene[i].playerIsInLight)
            {
                output = true;
            }
        }

        isInLight = output;
    }
}

