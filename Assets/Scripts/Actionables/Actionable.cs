using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actionable : MonoBehaviour
{
    protected bool actionate;

    public abstract void Execute();
}
