using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    int HitCount;
    void Start()
    {
        HitCount = 0;
    }

    void Update()
    {
        if (8 < HitCount)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "BackBall")
        {
            HitCount++;
        }
    }

}
