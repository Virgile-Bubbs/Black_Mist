using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowUI : MonoBehaviour
{
    public Canvas canvas;

    public GameObject actionUI;
    public Sprite img_monter;

    private bool show;

    private void Start()
    {
        show = false;
        actionUI.SetActive(false);
    }

    public bool IsShowing()
    {
        return show;
    }

    public void SetIsShowing(bool state)
    {
        show = state;
    }

    public void ShowMessage(Sprite img, string message)
    {
        actionUI.SetActive(true);
        actionUI.GetComponentInChildren<TextMeshProUGUI>().text = message;
        actionUI.GetComponentInChildren<Image>().sprite = img;
        SetIsShowing(true);
    }

    public void ShowMessageDescendre()
    {
        Sprite image = Resources.Load<Sprite>("Textures/Textures_self/Touche_E");
        string message = "Descendre";
        ShowMessage(image, message);
    }

    public void ShowMessageMonter()
    {
        Sprite image = Resources.Load<Sprite>("Textures/Textures_self/Touche_E");
        string message = "Monter";
        ShowMessage(image, message);
    }

    public void HideMessage()
    {
        actionUI.SetActive(false);
        SetIsShowing(false);
    }
}
