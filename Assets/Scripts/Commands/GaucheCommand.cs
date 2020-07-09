using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaucheCommand : Command
{
    public GaucheCommand(KeyCode _key)
    {
        SetKey(_key);
    }

    public override void Execute()
    {
        actions.Gauche();
    }
}
