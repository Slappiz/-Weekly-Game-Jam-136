using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMenu : MonoBehaviour
{
    public MainMenu mainMenu = null;
    public Slider masterVolume;
    public Button closeButton;

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
