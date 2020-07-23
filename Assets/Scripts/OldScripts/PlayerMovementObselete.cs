using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementObsolete : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);



    }
}
