using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Goal redGoal;
    public Goal blueGoal;

    private void Start()
    {
        SoundManager.instance.Play("Lunar");
    }

    private void FixedUpdate()
    {
        if (redGoal.onPlayer && blueGoal.onPlayer)
        {
            Debug.Log("Game Won");
        }
    }
}
