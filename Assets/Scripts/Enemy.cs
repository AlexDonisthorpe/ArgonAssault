using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BoxCollider _boxCollider;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    Scoreboard _scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
        _scoreboard = FindObjectOfType<Scoreboard>();
    }

    private void AddBoxCollider()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            _boxCollider = gameObject.AddComponent<BoxCollider>();
            _boxCollider.isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        _scoreboard.AddScore(scorePerHit);
        StartDeathFX();
        Destroy(gameObject);
    }

    private void StartDeathFX()
    {
        GameObject explosion = Instantiate(deathFX, transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.transform.parent = parent;
    }
}
