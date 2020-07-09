using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescendreCommand : Command
{
    public DescendreCommand(KeyCode _key)
    {
        SetKey(_key);
    }

    public override void Execute()
    {
        actions.Descend();
    }

}
