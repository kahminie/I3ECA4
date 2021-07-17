/******************************************************************************
Author: Darrik Tan

Name of Class: DemoPlayer

Description of Class: This class will control the movement and actions of a 
                        player avatar based on user input.

Date Created: 
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer : MonoBehaviour
{
    /// <summary>
    /// The distance this player will travel per second.
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// The power of the player's jump
    /// </summary>
    public float jumpPower;

    public Rigidbody myRigidbody;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float interactionDistance;

    private bool isGrounded = true;

    private bool doublejumped = false;

    public int numKey = 0;
    public int numCoin = 0;
    public int numWeapon = 0;

    /// <summary>
    /// The camera attached to the player model.
    /// Should be dragged in from Inspector.
    /// </summary>
    [SerializeField]
    private Camera playerCamera;

    private string currentState;

    private string nextState;

    // Start is called before the first frame update
    void Start()
    {
        nextState = "Idle";
    }

    // Update is called once per frame
    void Update()
    {
        if (nextState != currentState)
        {
            SwitchState();
        }

        CheckRotation();
        InteractionRaycast();
        CheckJump();
        GroundRaycast();
    }

    private void InteractionRaycast()
    {
        Debug.DrawLine(playerCamera.transform.position,
                    playerCamera.transform.position + playerCamera.transform.forward * interactionDistance);

        int layermask = 1 << LayerMask.NameToLayer("Interactable");

        RaycastHit hitinfo;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward,
            out hitinfo, interactionDistance, layermask))
        {
            // if my ray hits something, if statement is true
            // do stuff here
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hitinfo.transform.tag == "Teleporter")
                {
                    hitinfo.transform.GetComponent<Teleporting>().Interact();
                }
                if (hitinfo.transform.tag == "Key")
                {
                    hitinfo.transform.GetComponent<Collectibles>().Interact();
                }
                if (hitinfo.transform.tag == "Coins")
                {
                    hitinfo.transform.GetComponent<Collectibles>().Interact();
                }
                if (hitinfo.transform.tag == "KeyDoor")
                {
                    hitinfo.transform.GetComponent<BlockedDoor>().Interact();
                }
                if (hitinfo.transform.tag == "CoinDoor")
                {
                    hitinfo.transform.GetComponent<BlockedDoor>().Interact();
                }
                if (hitinfo.transform.tag == "Weapon")
                {
                    hitinfo.transform.GetComponent<Collectibles>().Interact();
                }
                if (hitinfo.transform.tag == "TreasureDoor")
                {
                    hitinfo.transform.GetComponent<BlockedDoor>().Interact();
                }
            }
        }
    }

    private void GroundRaycast()
    {
        Debug.DrawLine(playerCamera.transform.position, Vector3.down * 0.01f);

        int groundmask = 1 << LayerMask.NameToLayer("Ground");

        RaycastHit hitinfo;
        if (Physics.Raycast(playerCamera.transform.position, Vector3.down, out hitinfo, 0.1f, groundmask))
        {
            if (hitinfo.collider != null)
            {
                isGrounded = true;
                doublejumped = false;
            }
            else
            {
                isGrounded = false;
            }
        }
    }

    public void IncreaseKey()
    {
        ++numKey;
        Debug.Log(numKey);
    }

    public void IncreaseCoin()
    {
        numCoin += 1;
        Debug.Log(numCoin);
    }

    public void IncreaseWeapon()
    {
        numWeapon += 1;
        Debug.Log(numWeapon);
    }

    /// <summary>
    /// Sets the current state of the player
    /// and starts the correct coroutine.
    /// </summary>
    private void SwitchState()
    {
        StopCoroutine(currentState);

        currentState = nextState;
        StartCoroutine(currentState);
    }

    private IEnumerator Idle()
    {
        while (currentState == "Idle")
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                nextState = "Moving";
            }
            yield return null;
        }
    }

    private IEnumerator Moving()
    {
        while (currentState == "Moving")
        {
            if (!CheckMovement())
            {
                nextState = "Idle";
            }
            yield return null;
        }
    }

    private void CheckRotation()
    {
        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(playerRotation);

        Vector3 cameraRotation = playerCamera.transform.rotation.eulerAngles;
        cameraRotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
    }

    /// <summary>
    /// Checks and handles movement of the player
    /// </summary>
    /// <returns>True if user input is detected and player is moved.</returns>
    private bool CheckMovement()
    {
        Vector3 newPos = transform.position;

        Vector3 xMovement = transform.right * Input.GetAxis("Horizontal");
        Vector3 zMovement = transform.forward * Input.GetAxis("Vertical");

        Vector3 movementVector = xMovement + zMovement;

        if (movementVector.sqrMagnitude > 0)
        {
            movementVector *= moveSpeed * Time.deltaTime;
            newPos += movementVector;

            transform.position = newPos;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Checks for player input to execute jumping
    /// </summary>
    private void CheckJump()
    {
        if (isGrounded)
        { 
            Debug.Log("jump");
            // If the player presses Spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            }
        }
        else
        {
            if (!doublejumped)
            {
                myRigidbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
                doublejumped = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionFunction(collision);
    }

    protected virtual void CollisionFunction(Collision collision)
    {
        Debug.Log("hi");
    }
}

