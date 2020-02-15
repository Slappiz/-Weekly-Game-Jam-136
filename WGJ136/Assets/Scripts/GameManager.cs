using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Goal redGoal;
    public Goal blueGoal;

    private void FixedUpdate()
    {
        if (redGoal.onPlayer && blueGoal.onPlayer)
        {
            Debug.Log("Game Won");
        }
    }
}
