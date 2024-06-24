using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player to follow
    public Vector3 offset; // The offset relative to the player
    public float smoothSpeed = 0.125f; // Smooth speed for camera movement
    public float rotationSpeed = 5.0f; // Speed of camera rotation

    private float currentRotationX = 0f;
    private float currentRotationY = 0f;

    void LateUpdate()
    {
        // Get mouse input
        currentRotationX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentRotationY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentRotationY = Mathf.Clamp(currentRotationY, -40, 60); // Clamp the vertical rotation

        // Calculate desired position and rotation
        Quaternion rotation = Quaternion.Euler(currentRotationY, currentRotationX, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;

        // Make the camera look at the player
        transform.LookAt(target.position);
    }
}
