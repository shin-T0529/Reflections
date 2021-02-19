using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_SetPosCamera : MonoBehaviour
{
    //public.
    public GameObject SetCamera;
    //Local.
    int SetCount;

    void Start()
    {
        SetCount = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if (BallMove.BallMoveStart == true && SetCount == 0)
        {
            SetCount++;
            //変更前はprefabのMain Cameraの座標(ここでは動かす分だけ数値を入れる).
            SetCamera.transform.Translate(23.4f, 0.0f, 0.0f);
        }
    }
}
