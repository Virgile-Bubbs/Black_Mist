using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCommand : Command
{
    public ActionCommand(KeyCode _key)
    {
        SetKey(_key);
    }

    public override void Execute()
    {
        actions.PlayerAction();
    }
}
