using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BoxCollider _boxCollider;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameObject.GetComponent<BoxCollider>()) {
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
        print("Particles collided with enemy" + gameObject.name);
        GameObject explosion = Instantiate(deathFX, transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.transform.parent = parent;
        Destroy(gameObject);
    }
}
