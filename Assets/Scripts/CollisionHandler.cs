using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("FX Prefab on player")][SerializeField] GameObject deathFX;
    LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();

       // StartDeathSequence();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player is dying");
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        levelLoader.ReloadLevel();
    }
}
