using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected KeyCode key;
    public Actions actions;

    public Command()
    {
        actions = GameObject.Find("Engine").GetComponent<Actions>();
    }

    public KeyCode GetKey()
    {
        return key;
    }

    public void SetKey(KeyCode _key)
    {
        key = _key;
    }

    public abstract void Execute();
}
