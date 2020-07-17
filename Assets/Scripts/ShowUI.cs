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
    private GameObject actionMessage;

    private bool show;

    private void Start()
    {
        SetIsShowing(true);
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
        actionMessage = Instantiate(actionUI, canvas.transform) as GameObject;
        actionMessage.GetComponentInChildren<TextMeshProUGUI>().text = message;
        actionMessage.GetComponentInChildren<Image>().sprite = img;
        SetIsShowing(true);
        actionMessage.gameObject.SetActive(true);
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
        Destroy(actionMessage);
        SetIsShowing(false);
    }
}
