using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Goal redGoal;
    public Goal blueGoal;
    public InputHandler playerBlue;
    public InputHandler playerRed;
    private bool gameWon = false;
    
    private void Start()
    {
        SoundManager.instance.Play("Lunar");
    }

    private void FixedUpdate()
    {
        if (gameWon) return;
        
        if (redGoal.onPlayer && blueGoal.onPlayer)
        {
            gameWon = true;
            playerBlue.enabled = false;
            playerBlue.SetHappy();
            playerRed.enabled = false;
            playerRed.SetHappy();
            Invoke("WinGame", 1f);
        }
    }

    private void WinGame()
    {
        
    }
}
