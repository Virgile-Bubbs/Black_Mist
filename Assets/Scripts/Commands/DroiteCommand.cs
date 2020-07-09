using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroiteCommand : Command
{
    public DroiteCommand(KeyCode _key)
    {
        SetKey(_key);
    }

    public override void Execute()
    {
        actions.Droite();
    }
}
