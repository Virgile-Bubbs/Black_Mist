using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reliques : Items
{
    public Inventaire inventaire;

    public override void Execute()
    {
        actionate = true;
        inventaire.AddItem(this);
        gameObject.SetActive(false);
    }

    public bool isActionate()
    {
        return actionate;
    }
}
