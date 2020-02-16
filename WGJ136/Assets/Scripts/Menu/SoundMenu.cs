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
        masterVolume.onValueChanged.AddListener(SetVolume);
        masterVolume.value = 1;
    }

    void CloseMenu()
    {
        mainMenu.ButtonsActive();
        gameObject.SetActive(false);
    }

    void SetVolume(float value)
    {
        SoundManager.instance.MasterVolume(value); 
    }
}
