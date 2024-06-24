using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    public Transform cameraTransform; // Reference to the camera's transform

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is on the ground
        if (characterController.isGrounded)
        {
            // Read input from keyboard
            float horizontalMove = Input.GetAxis("Horizontal");
            float verticalMove = Input.GetAxis("Vertical");

            // Calculate the movement direction relative to the camera
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;

            forward.y = 0f; // We don't want the player to move up or down
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            // Set the movement direction based on input
            moveDirection = forward * verticalMove + right * horizontalMove;
            moveDirection *= speed;

            // Handle jumping
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the player
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
