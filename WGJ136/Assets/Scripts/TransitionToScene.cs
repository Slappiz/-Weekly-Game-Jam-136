using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToScene : MonoBehaviour
{
    public string sceneToLoad = "MainMenu";

    private void Start()
    {
        Invoke("Transition", 4f);
    }

    void Transition()
    {
        SoundManager.instance.Stop("Lunar");
        SceneManager.LoadScene(sceneToLoad);
    }
}
