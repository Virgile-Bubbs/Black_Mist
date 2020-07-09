using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonterCommand : Command
{
    public MonterCommand(KeyCode _key)
    {
        SetKey(_key);
    }

    public override void Execute()
    {
        actions.Monte();
    }
}
