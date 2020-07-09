using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaisseauController : Actionable
{
    public GameObject player;
    public Actions actions;

    private Rigidbody rb;
    public float speed;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;
    private bool isPlayerIn;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isPlayerIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        actions.SetPlayerIn(isPlayerIn);

        if (isPlayerIn)
            player.transform.position = transform.position;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public void SetIsGrounded(bool state)
    {
        isGrounded = state;
    }

    public bool IsPlayerIn()
    {
        return isPlayerIn;
    }

    public void SetIsPlayerIn(bool state)
    {
        isPlayerIn = state;
    }

    public override void Execute()
    {
        if (!isPlayerIn)
            EnterVaisseau();
    }

    public void Monte()
    {
        rb.AddForce(transform.up * speed * Time.deltaTime);
    }

    public void Descend()
    {
        rb.AddForce(-transform.up * speed * Time.deltaTime);
    }

    public void Avance()
    {
        if(!isGrounded)
            rb.AddForce(transform.forward * speed * Time.deltaTime);
    }

    public void Recule()
    {
        if(!isGrounded)
            rb.AddForce(-transform.forward * speed * Time.deltaTime);
    }

    public void Droite()
    {
        if(!isGrounded)
            rb.AddForce(transform.right * speed * Time.deltaTime);
    }

    public void Gauche()
    {
        if(!isGrounded)
            rb.AddForce(-transform.right * speed * Time.deltaTime);
    }

    public void EnterVaisseau()
    {
        player.transform.position = transform.position;
        transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 0; i < player.transform.childCount; i++)
        {
            player.transform.GetChild(i).gameObject.SetActive(false);
        }

        player.GetComponent<CapsuleCollider>().enabled = false;

        isPlayerIn = true;
    }

    public void ExitVaisseau()
    {
        player.transform.position = transform.position + new Vector3(2, 0, 0);
        transform.GetChild(0).gameObject.SetActive(false);
        for (int i = 0; i < player.transform.childCount; i++)
        {
            player.transform.GetChild(i).gameObject.SetActive(true);
        }

        player.GetComponent<CapsuleCollider>().enabled = true;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        isPlayerIn = false;
    }

   

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Gravity")
        {
            GetComponent<GravityBody>().enabled = false;
            //Debug.Log("EXIT");
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gravity")
        {          
            GetComponent<GravityBody>().attractorPlanet = other.GetComponent<GravityEnter>().planet.GetComponent<PlanetScript>();
            GetComponent<GravityBody>().enabled = true;
            //Debug.Log("ENTER");
        }
    }

    
}
