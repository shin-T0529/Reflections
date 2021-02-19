using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    //Local.
    //上限を決める(これは適宜設定を外部に出して読み込むなどして対応してください）
    //オプションなどでこの値を変更できるようにするとユーザーフレンドリーかもしれません
    float maxWidth = 1440.0f;
    float maxHeight = 2960.0f;


    //オーバーし過ぎている方から縮小率を得る
    public float rate;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //それぞれのオーバーしている倍率を求める
        float scaleWidth = (float)Screen.width / maxWidth;
        float scaleHeight = (float)Screen.height / maxHeight;

        if (scaleWidth > scaleHeight)
        {
            rate = scaleWidth;
        }
        else
        {
            rate = scaleHeight;
        }

        //上限よりオーバーしていたら元々のアスペクト比を保ったまま解像度を縮小する
        if (rate > 1.0f)
        {
            //切り上げで計算(1ドット欠けを防ぐ）
            int setWidth = Mathf.CeilToInt((float)Screen.width / rate);
            int setHeight = Mathf.CeilToInt((float)Screen.height / rate);
            Screen.SetResolution(setWidth, setHeight, false);
        }
    }
}