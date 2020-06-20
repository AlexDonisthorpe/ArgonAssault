using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] float destroyTimer = 1f;

    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }

}