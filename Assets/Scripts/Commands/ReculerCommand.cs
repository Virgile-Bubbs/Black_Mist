using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReculerCommand : Command
{
    public ReculerCommand(KeyCode _key)
    {
        SetKey(_key);
    }

    public override void Execute()
    {
        actions.Recule();
    }
}
