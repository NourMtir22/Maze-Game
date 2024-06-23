using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpedSpeed;
    private float ySpeed;
    private CharacterController conn;
    public bool isGrounded;
    public Joystick joy;

    // Declare the missing variables
    private float horizontalSpeed;
    private float verticalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        conn = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        float joyHorizontalMove = joy.Horizontal * speed;
        float joyVerticalMove = joy.Vertical * speed;

        Vector3 moveDirection = new Vector3(horizontalMove, 0, verticalMove);
        moveDirection.Normalize();
        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        conn.SimpleMove(moveDirection * magnitude * speed);

        Vector3 joyMovement = new Vector3(joyHorizontalMove, 0, joyVerticalMove);
        joyMovement.Normalize();
        float joyMagnitude = joyMovement.magnitude;
        joyMagnitude = Mathf.Clamp01(joyMagnitude);
        conn.SimpleMove(joyMovement * joyMagnitude * speed);

        if (horizontalMove >= 0.2f)
        {
            horizontalSpeed = speed;
        }
        else if (horizontalMove <= -0.2f)
        {
            horizontalSpeed = -speed;
        }
        else
        {
            horizontalSpeed = 0f;
        }

        if (verticalMove >= 0.2f)
        {
            verticalSpeed = speed;
        }
        else if (verticalMove <= -0.2f)
        {
            verticalSpeed = -speed;
        }
        else
        {
            verticalSpeed = 0f;
        }

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            ySpeed = jumpedSpeed;
        }

        Vector3 vel = moveDirection * magnitude;
        vel.y = ySpeed;
        conn.Move(vel * Time.deltaTime);

        if (conn.isGrounded)
        {
            ySpeed = -0.5f;
            isGrounded = true;
            if (Input.GetButton("Jump"))
            {
                ySpeed = jumpedSpeed;
                isGrounded = false;
            }
        }

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }
}
