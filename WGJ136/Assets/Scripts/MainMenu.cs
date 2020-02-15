using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject andObj = null;
    public Button startButton = null;
    public Button controlsButton = null;
    public Button soundButton = null;

    private void Awake()
    {
        andObj.SetActive(false);
        ButtonsHide();
        Invoke("ButtonsActive", 3f);
    }

    void Start()
    {
        SoundManager.instance.Play("Seafoam");
        startButton.onClick.AddListener(HandleStartButton);
    }

    void HandleStartButton()
    {
        SoundManager.instance.Stop("Seafoam");
        SceneManager.LoadScene("Level1");
    }
    
    
    void ButtonsActive()
    {
        startButton.gameObject.SetActive(true);
        controlsButton.gameObject.SetActive(true);
        soundButton.gameObject.SetActive(true); 
        andObj.SetActive(true);
    }

    void ButtonsHide()
    {
        startButton.gameObject.SetActive(false);
        controlsButton.gameObject.SetActive(false);
        soundButton.gameObject.SetActive(false); 
    }
}
