using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    private List<Items> actionables;

    private void Awake()
    {
        actionables = new List<Items>();
    }

    public void AddItem(Items item)
    {
        actionables.Add(item);
    }

    public bool ContainItem(Items item)
    {
        return actionables.Contains(item);
    }
}
