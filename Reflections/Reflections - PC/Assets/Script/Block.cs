using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    { 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
