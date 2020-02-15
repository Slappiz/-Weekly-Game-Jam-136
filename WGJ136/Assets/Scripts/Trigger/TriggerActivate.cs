using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate : MonoBehaviour
{
    public GameObject child;

    private void Awake()
    {
        child.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        child.SetActive(true);
    }
}
