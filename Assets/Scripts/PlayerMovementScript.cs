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


    public void Avance()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveVertical) * moveSpeed * Time.deltaTime);
    }

    public void Recule()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveVertical) * (moveSpeed / 2) * Time.deltaTime);
    }

    public void Droite()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveHorizontal) * moveSpeed * Time.deltaTime);
    }

    public void Gauche()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveHorizontal) * moveSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if(isGrounded)
            rb.AddForce(transform.up * jumpForce);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gravity")
        {
            GetComponent<GravityBody>().enabled = false;
            //Debug.Log("EXIT");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gravity")
        {
            GetComponent<GravityBody>().attractorPlanet = other.GetComponent<GravityEnter>().planet.GetComponent<PlanetScript>();
            GetComponent<GravityBody>().enabled = true;
            //Debug.Log("ENTER");
        }
    }
}
