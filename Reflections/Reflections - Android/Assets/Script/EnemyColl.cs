using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColl : MonoBehaviour
{
    //pub.
    public GameObject Attacker;

    //pri.

    //pub sta.

    //Local.


    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Attacker.SetActive(true);
            Debug.Log("AttackStart!");
        }
    }

}
