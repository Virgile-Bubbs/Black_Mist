using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaisseauController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddForce(-transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed * Time.deltaTime);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Gravity")
        {
            GetComponent<PlayerGravityBody>().enabled = false;
            Debug.Log("EXIT");
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gravity")
        {          
            GetComponent<PlayerGravityBody>().attractorPlanet = other.GetComponent<GravityEnter>().planet.GetComponent<PlanetScript>();
            GetComponent<PlayerGravityBody>().enabled = true;
            Debug.Log("ENTER");
        }
    }

    
}
