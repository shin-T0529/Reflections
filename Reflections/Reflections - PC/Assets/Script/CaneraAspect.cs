using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneraAspect : MonoBehaviour
{
    //public
    public float defaultWidth = 720.0f;         //最初に作った画面のwidth.
    public float defaultHeight = 1280.0f;       //最初に作った画面のheight.



    void Start()
    {

    }
    void Update()
    {
        //camera.mainを変数に格納
        Camera mainCamera = Camera.main;

        //最初に作った画面のアスペクト比 
        float defaultAspect = defaultWidth / defaultHeight;

        //実際の画面のアスペクト比
        float actualAspect = (float)Screen.width / (float)Screen.height;

        //実機とunity画面の比率
        float ratio = actualAspect / defaultAspect;

        //サイズ調整
        mainCamera.orthographicSize /= ratio;

    }
}
