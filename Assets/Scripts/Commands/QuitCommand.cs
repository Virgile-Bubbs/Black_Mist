using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCommand : Command
{
    public QuitCommand(KeyCode _key)
    {
        SetKey(_key);
    }

    public override void Execute()
    {
        actions.Quit();
    }
}
