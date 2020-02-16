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
            playerBlue.GetComponent<Rigidbody2D>().velocity = new Vector2(0, playerBlue.GetComponent<Rigidbody2D>().velocity.y);
            
            playerRed.enabled = false;
            playerRed.SetHappy();
            playerRed.GetComponent<Rigidbody2D>().velocity = new Vector2(0, playerRed.GetComponent<Rigidbody2D>().velocity.y);

            
            Invoke("WinGame", 1f);
        }
    }

    private void WinGame()
    {
        
    }
}
