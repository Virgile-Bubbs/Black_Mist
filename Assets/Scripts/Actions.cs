using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public GameObject player;
    public GameObject vaisseau;
    public PlayerMovementScript playerMovement;
    public VaisseauController vaisseauController;
    public ShowUI ui;

    bool isPlayerIn;
    bool isTargetingActionable;

    RaycastHit hit;
    Actionable currentActionable;

    private void Start()
    {
        isPlayerIn = false;
        isTargetingActionable = false;
    }

    public void PlayerJump()
    {
        playerMovement.Jump();
    }

    public void PlayerAction()
    {
        if(isTargetingActionable)
            currentActionable.Execute();
    }

    public void Avance()
    {
        if (isPlayerIn)
            vaisseauController.Avance();
        else
            playerMovement.Avance();
    }

    public void Recule()
    {
        if (isPlayerIn)
            vaisseauController.Recule();
        else
            playerMovement.Recule();
       
    }

    public void Droite()
    {
        if (isPlayerIn)
            vaisseauController.Droite();
        else
            playerMovement.Droite();
    }

    public void Gauche()
    {
        if (isPlayerIn)
            vaisseauController.Gauche();
        else
            playerMovement.Gauche();
    }

    public void Monte()
    {
        if (isPlayerIn)
            vaisseauController.Monte();
    }

    public void Descend()
    {
        if (isPlayerIn)
            vaisseauController.Descend();
    }

    public void Quit()
    {
        if(isPlayerIn && vaisseauController.IsGrounded())
        {
            vaisseauController.ExitVaisseau();
        }
    }

    public void SetPlayerIn(bool state)
    {
        isPlayerIn = state;
    }

    private void Update()
    {
       
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 2.0f))
        {
            
            //Layer 11 is Actionable
            if (hit.collider.gameObject.layer == 11)
            {
                CanActionate(hit);
            }
            else
            {
                if (ui.IsShowing())
                {
                    ui.HideMessage();
                }
                    
            }
        }
        else
        {
            if (ui.IsShowing())
            {
                ui.HideMessage();
            }
                

            isTargetingActionable = false;
            currentActionable = null;
        }
    }

    private void CanActionate(RaycastHit hit)
    {
        isTargetingActionable = true;
        currentActionable = hit.collider.gameObject.GetComponent<Actionable>();

        if (hit.collider.tag == "Vaisseau" && !ui.IsShowing())
        {
            if (isPlayerIn && vaisseauController.IsGrounded())
                ui.ShowMessageDescendre();
            else if (!isPlayerIn && vaisseauController.IsGrounded())
                ui.ShowMessageMonter();
        }
    }
}
