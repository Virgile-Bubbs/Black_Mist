using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject vaisseau;
    private bool inVaisseau;

    private void Start()
    {
        inVaisseau = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!inVaisseau)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
            {
                if (hit.collider.tag == "Vaisseau")
                {
                    Debug.Log("HIT VAISSEAU");

                    if (Input.GetKey(KeyCode.E))
                    {
                        EnterVaisseau();
                    }
                }
            }
        }

        else
        {
            transform.position = vaisseau.transform.position;
            if(vaisseau.GetComponent<VaisseauController>().isGrounded)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    ExitVaisseau();
                }
            }         
        }     
    }

    void EnterVaisseau()
    {
        inVaisseau = true;
        transform.position = vaisseau.transform.position;
        vaisseau.GetComponent<VaisseauController>().enabled = true;
        vaisseau.transform.GetChild(0).gameObject.SetActive(true);
        for(int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        GetComponent<PlayerMovementScript>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    void ExitVaisseau()
    {
        inVaisseau = false;
        transform.position = vaisseau.transform.position + new Vector3(2, 0, 0);
        vaisseau.GetComponent<VaisseauController>().enabled = false;
        vaisseau.transform.GetChild(0).gameObject.SetActive(false);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        GetComponent<PlayerMovementScript>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
