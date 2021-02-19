using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreProc : MonoBehaviour
{
    //pub.
    public Text ScoreText;
    public Text HighScoreText;
    public Text GetScore;
    public Text CompHighScore;

    public GameObject HighText;
    public string inData = string.Empty;

    //pub cons.

    //pri.

    //pub sta.
    static public int Score;
    static public int HighScore = 0;        //更新を続けるから代入初期化.
    static public int ReportScore;          //記録用スコア.
    static public int ReportTimeBonus = 0;  //時間ボーナス記録用.

    //Local.
    int inCompHighScore = 0;

    void Start()
    {
        ReportScore = 0;
        ReportTimeBonus = 0;
        //毎回読み込みを行う.
        ExPortData.Loadtext(ExPortData.GetInternalStoragePath(), 
                            "HighScoreData.txt",
                            inData, ref ReportScore);

        Debug.Log(ReportScore);
        HighScore = ReportScore;

        Score = 0;
    }

    void Update()
    {
        inCompHighScore = Score + TimeProc.ConvertTime;
        ReportTimeBonus = TimeProc.ConvertTime;
        ScoreText.text = " " + Score;
        HighScoreText.text = " " + HighScore;
        GetScore.text = "獲得スコア：" + Score;
        CompHighScore.text = "総獲得スコア：" + inCompHighScore;

        if (Clear.BlockGoal == true || Clear.StageClear == true)
        {
            //スコアの記録(クリアした時のみ).
            if (HighScore < (Score + ReportTimeBonus) && Clear.BlockDead == false)
            {
                //ハイスコア更新.
                HighScore = Score + ReportTimeBonus;
                ReportScore = HighScore;
                //ローカルファイルへ書き込み.
                ExPortData.SaveText(ExPortData.GetInternalStoragePath(),
                            "HighScoreData.txt",
                            ReportScore.ToString());
                HighText.SetActive(true);
            }
        }
    }

}
