using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject andObj = null;
    
    [Header("Main Buttons")]
    public Button startButton = null;
    public Button controlsButton = null;
    public Button soundButton = null;
    
    [Header("Controls Menu")]
    public GameObject controlsMenu = null;
    
    [Header("Sound Menu")]
    public GameObject soundMenu = null;
    
    
    private void Awake()
    {
        andObj.SetActive(false);
        controlsMenu.SetActive(false);
        soundMenu.SetActive(false);
        
        ButtonsHide();
        Invoke("ButtonsActive", 3f);
    }

    void Start()
    {
        SoundManager.instance.Play("Seafoam");
        startButton.onClick.AddListener(HandleStartButton);
        controlsButton.onClick.AddListener(HandleControlsButton);
        soundButton.onClick.AddListener(HandleSoundButton);
    }

    void HandleStartButton()
    {
        SoundManager.instance.Stop("Seafoam");
        SceneManager.LoadScene("Level1");
    }

    void HandleControlsButton()
    {
        ButtonsHide();
        controlsMenu.SetActive(true);
    }

    void HandleSoundButton()
    {
        ButtonsHide();
        soundMenu.SetActive(true);
    }
    
    public void ButtonsActive()
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
