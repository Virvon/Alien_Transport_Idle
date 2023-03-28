using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    public event UnityAction<bool> Clicked;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Clicked?.Invoke(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Clicked?.Invoke(false);
    }
}
