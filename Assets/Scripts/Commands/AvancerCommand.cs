using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvancerCommand : Command
{
    public AvancerCommand(KeyCode _key)
    {
        SetKey(_key);
    }

    public override void Execute()
    {
        actions.Avance();
    }
}
