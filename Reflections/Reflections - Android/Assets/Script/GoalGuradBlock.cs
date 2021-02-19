using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGuradBlock : MonoBehaviour
{
    //pub.
    public Material[] _BlockColor;
    //pri.
    private int HitCount;
    //pub sta.

    //Local.
    bool Dest;

    void Start()
    {
        HitCount = 0;
        Dest = false;
    }

    void Update()
    {
        //HitCount = HitCount;

        if(Dest == false)
        {
            this.GetComponent<Renderer>().material = _BlockColor[HitCount];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HitCount++;
        if (3 <= HitCount)
        {
            Dest = true;
            Destroy(gameObject);
        }
    }

}
