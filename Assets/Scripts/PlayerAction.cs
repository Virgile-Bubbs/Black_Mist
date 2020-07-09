using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAction : MonoBehaviour
{
    public GameObject vaisseau;
    private bool inVaisseau;

    public Canvas canvas;

    public GameObject actionUI;
    public Sprite img_monter;
    private GameObject ui;

    bool isShowing;

    private void Start()
    {
        inVaisseau = false;
        isShowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isShowing);
        if(!inVaisseau)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
            {
                if (hit.collider.tag == "Vaisseau")
                {
                    if(!isShowing)
                        ShowActionUI(img_monter, "Monter");

                    if (Input.GetKey(KeyCode.E))
                    {
                        EnterVaisseau();
                    }
                }
                
            }

            else
            {
                if (isShowing)
                {
                    Destroy(ui);
                    isShowing = false;
                }
            }
        }

        else
        {
            
            if (isShowing)
            {
                 Destroy(ui);
                 isShowing = false;
            }
     

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

    void ShowActionUI(Sprite img, string message)
    {
        ui = Instantiate(actionUI, canvas.transform) as GameObject;
        ui.GetComponentInChildren<TextMeshProUGUI>().text = message;
        ui.GetComponentInChildren<Image>().sprite = img;
        isShowing = true;
    }
}
