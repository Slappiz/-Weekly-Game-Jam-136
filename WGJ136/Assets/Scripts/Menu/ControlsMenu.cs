using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour
{
    public MainMenu mainMenu = null;
    public Button closeButton = null;
    
    void Start()
    {
        closeButton.onClick.AddListener(CloseMenu);
    }

    void CloseMenu()
    {
        mainMenu.ButtonsActive();
        gameObject.SetActive(false);
    }
}
