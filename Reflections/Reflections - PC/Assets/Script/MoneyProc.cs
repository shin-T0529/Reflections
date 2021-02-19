using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.IO;

public class MoneyProc : MonoBehaviour
{
    //pub
    public Text MoneyText;

    public string inDataMoney = string.Empty;

    //pri

    //pub sta
    public static int SocreMoney = 0;        //スコアをアイテム購入の金にする.
    public static bool BuyMoney;             //購入時の記録用フラグ.

    //local
    bool AddMoney;                           //クリア時の加算記録用フラグ.
    int ReportMoney = 0;


    void Start()
    {
        //毎回読み込む.
        ExPortData.Loadtext(ExPortData.GetInternalStoragePath(),
                    "S_MoneyData.txt",
                    inDataMoney, ref ReportMoney);

        Debug.Log(ReportMoney);

        SocreMoney = ReportMoney;
        AddMoney = false;
        BuyMoney = false;
    }


    void Update()
    {
        MoneyUpdate();
        if (SceneManager.GetActiveScene().name == "SHOP" && BuyMoney == true)
        {
            ReportMoney = SocreMoney;
            //ローカルファイルへ書き込み.
            ExPortData.SaveText(ExPortData.GetInternalStoragePath(),
                        "S_MoneyData.txt",ReportMoney.ToString());
            BuyMoney = false;
        }
    }

    void MoneyUpdate()
    {
        if (Clear.BlockGoal == true && AddMoney == false
         || Clear.StageClear == true && AddMoney == false)
        {
            SocreMoney = SocreMoney + ScoreProc.Score / 10;
            ReportMoney = SocreMoney;
            //ローカルファイルへ書き込み.
            ExPortData.SaveText(ExPortData.GetInternalStoragePath(),
                        "S_MoneyData.txt",ReportMoney.ToString());
            AddMoney = true;
        }
        MoneyText.text = " : " + SocreMoney;
    }
}
