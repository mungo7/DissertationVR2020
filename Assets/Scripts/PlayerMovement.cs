using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    //Instantiate values for speed, gravity, and jumping height
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //These are used for the correct calculation of gravity on the player character
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //Create a Vector3 to store velocity
    Vector3 velocity;
    //This boolean value is determined by whether or not the player is touching the ground
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Updated isGrounded by checking if the player's groundCheck object is touching an object of the Ground layer
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //If the player is grounded, reset their velocity on the y axis to -1
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        //Retrieve values for player input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        //Move the player according to the values determined in the above Vector3 move
        controller.Move(move * speed * Time.deltaTime);

        //Jump clause
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        } 

        //Modify the player's y velocity by gravity over time. This will cause realistic falling.
       velocity.y += gravity * Time.deltaTime;

        //Move the player according to their velocity
        controller.Move(velocity * Time.deltaTime);

    }
}
