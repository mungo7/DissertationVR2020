using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Declare mouse sensitivity, create Transform object for player, and initiate xRotation
    public float mouseSpeed = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Obtain values for mouse movement on the X and Y axes
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;


        //Negate the value of movement on the Y axis in order for a non-inverted rotation 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Apply xRotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Apply rotation on Y axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
