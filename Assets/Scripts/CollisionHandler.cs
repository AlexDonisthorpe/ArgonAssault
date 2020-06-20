using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void Start()
    {
        //StartDeathSequence();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player is dying");
        SendMessage("OnPlayerDeath");
    }
}
