using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeProc : MonoBehaviour
{
    //pub.
    public Text TimeText;
    public Text BonusText;

    //pri.

    //pub sta.
    public static int ConvertTime;

    //Local.
    int Time_S;
    int Time_ss;    //100秒で１秒換算.
    int BonusMode;

    void Start()
    {
        ConvertTime = 0;
        BonusMode = 0;
    }

    void Update()
    {
        TimeText.text = " " + Time_S + "." + Time_ss;
        BonusText.text = "タイムボーナス：" + ConvertTime;
        BonusScorecheck();
        TimeCount();
    }

    void TimeCount()
    {
        if (Clear.BlockGoal == false
         && Clear.BlockDead == false
         && Clear.StageClear == false
         && BallMove.BallMoveStart == true)
        {
            if (Time_ss < 99)
            {
                Time_ss++;
            }
            else
            {
                Time_ss = 0;
                Time_S++;
            }
        }
    }

    void BonusScorecheck()
    {
        //基本制限時間+アイテム使用の追加分10s.
        if(Time_S <= 20 + ItemProc.TimeBonudUP_mag * 10)
        {
            BonusMode = 1;
        }
        else if (20 + (ItemProc.TimeBonudUP_mag * 10) < Time_S 
                && Time_S <= 60 + ItemProc.TimeBonudUP_mag * 10)
        {
            BonusMode = 2;
        }
        else if (60 + (ItemProc.TimeBonudUP_mag * 10) < Time_S 
                && Time_S <= 100 + ItemProc.TimeBonudUP_mag * 10)
        {
            BonusMode = 3;
        }
        else if (100 + (ItemProc.TimeBonudUP_mag * 10) < Time_S 
                && Time_S <= 150 + ItemProc.TimeBonudUP_mag * 10)
        {
            BonusMode = 4;
        }
        else
        {
            BonusMode = 0;
        }
        ConvertScore(BonusMode);
    }

    void ConvertScore(int i)
    {
        switch(i)
        {
            case 0:
                ConvertTime = 0;
                break;
            case 1:
                ConvertTime = 10000;
                break;
            case 2:
                ConvertTime = 5000;
                break;
            case 3:
                ConvertTime = 3000;
                break;
            case 4:
                ConvertTime = 1000;
                break;
            default:
                ConvertTime = 0;
                break;
        }
    }
}
