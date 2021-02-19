using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPProc : MonoBehaviour
{
    //pub.
    public GameObject OuObject;
    public GameObject TargetObject;

    //pri.

    //pub sta.

    //Local.
    Vector3 Pos;

    void Start()
    {

    }

    void Update()
    {
        //少しずらして表示をする.
        Pos.x = TargetObject.transform.position.x;
        Pos.y = TargetObject.transform.position.y;// + 2.8f;
        Pos.z = TargetObject.transform.position.z - 3.5f;

        OuObject.transform.position = Pos;
    }
}
