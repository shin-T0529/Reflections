using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ResultScenes : MonoBehaviour
{
    public string inData = string.Empty;
    public static bool LoadStart = false;

    string SceneNofileName = "SceneNoData.txt";
    int Scenedef = 1;
    void Start()
    {
        //起動時のみ読み込みを行い、続き/最初から行う.
        if (LoadStart == false)
        {

            ExPortData.Loadtext(ExPortData.GetInternalStoragePath(),
            "SceneNoData.txt", inData, ref ButtonProc.SceneNo);

            //ファイルが存在しないとき.
            if (ButtonProc.SceneNo == 0)
            {
                //最初の面に飛ばす.
                ButtonProc.SceneNo = 1;
            }

            LoadStart = true;
            SceneManager.LoadScene(ButtonProc.SceneNo);
        }
        else
        {
            //切り替える前に記録し、次回は選択したステージから始める.
            ExPortData.SaveText(ExPortData.GetInternalStoragePath(),
            "SceneNoData.txt", ButtonProc.SceneNo.ToString());
            SceneManager.LoadScene(ButtonProc.SceneNo);
        }

    }

    // Update is called once per frame
    void Update()
    {
        ////同上.
        //if(LoadStart == false)
        //{
        //    LoadStart = true;
        //    //切り替える前に記録し、ファイルの生成を行う.
        //    ExPortData.SaveText(ExPortData.GetInternalStoragePath(),
        //    "SceneNoData.txt", ButtonProc.SceneNo.ToString());
        //    SceneManager.LoadScene(ButtonProc.SceneNo);
        //}
        ////ステージセレクトでシーンを選択した場合.
        //else
        //{
        //    //切り替える前に記録し、次回は選択したステージから始める.
        //    ExPortData.SaveText(ExPortData.GetInternalStoragePath(),
        //    "SceneNoData.txt", ButtonProc.SceneNo.ToString());
        //    SceneManager.LoadScene(ButtonProc.SceneNo);
        //}
    }
}
