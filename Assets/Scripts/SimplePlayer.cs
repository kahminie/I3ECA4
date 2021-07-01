using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The speed at which the player rotates based on mouse movement.")]
    private float lookSpeed;

    [SerializeField]
    [Tooltip("The speed at which the player walks")]
    private float walkSpeed;

    [SerializeField]
    [Tooltip("The speed at which the player floats up or down")]
    private float floatSpeed;

    [SerializeField]
    [Tooltip("The walk speed multiplier when the player runs")]
    private float runMultiplier;

    Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse X") != 0)
        {
            Vector3 toRotate = transform.up * Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
            Vector3 newRotation = transform.rotation.eulerAngles + toRotate;
            transform.rotation = Quaternion.Euler(newRotation);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            playerAnimator.SetBool("isWalking", true);
            Vector3 toMove = Input.GetAxisRaw("Vertical") * transform.forward * walkSpeed * Time.deltaTime * (playerAnimator.GetBool("isRunning") ? runMultiplier : 1f);
            transform.position += toMove;
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }

        if(Input.GetKey(KeyCode.Q))
        {
            Vector3 toMove = transform.up * floatSpeed * Time.deltaTime;
            transform.position += toMove;
        }
        else if(Input.GetKey(KeyCode.E))
        {
            Vector3 toMove = transform.up * -floatSpeed * Time.deltaTime;
            transform.position += toMove;
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }
}
