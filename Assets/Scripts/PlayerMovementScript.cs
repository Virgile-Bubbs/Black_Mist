using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed = 1.5f;
    public float jumpForce = 2f;

    private Vector3 moveVertical;
    private Vector3 moveHorizontal;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;

 
    private Rigidbody rb;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        moveVertical = new Vector3(0, 0, Input.GetAxisRaw("Vertical")).normalized;
        moveHorizontal = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized;

        rb = GetComponent<Rigidbody>();
           
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Z))
            rb.MovePosition(rb.position + transform.TransformDirection(moveVertical) * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.MovePosition(rb.position + transform.TransformDirection(moveVertical) * (moveSpeed/2) * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            rb.MovePosition(rb.position + transform.TransformDirection(moveHorizontal) * moveSpeed * Time.deltaTime);    
        if (Input.GetKey(KeyCode.D))
            rb.MovePosition(rb.position + transform.TransformDirection(moveHorizontal) * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }

    }
}
