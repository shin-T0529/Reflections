using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ButtonProc : MonoBehaviour
{
    //pub.
    public GameObject TitleUI;
    public GameObject PlayUI;
    public GameObject JoySticks;
    public GameObject OffHighScoredesu;
    public GameObject GoalGuardBlock;

    public GameObject OnOff;               //汎用性の高いやつ.
    public GameObject OnOff2;               //汎用性の高いやつ.

    public GameObject Particle;

    public Image Fade;

    public AudioClip SE_LevelUp;
    public AudioClip SE_Buy;
    public AudioClip SE_BuyError;

    public string inData = string.Empty;

    //pri.
    private int TouchCnt;                 //ハードモード突入用.
    private AudioSource SESource;
    //pub sta.
    public static int inShopSceneNo;      //ショップに入る前のシーンNoを記録.
    public static int SceneNo;

    //Local.
    int SceneLow = 1;                     //最初の面.


    void Start()
    {
        TouchCnt = 0;

        SESource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //クリアした時にUI以外のONOFFを行う.
        if(Clear.BlockGoal == true || Clear.BlockDead == true 
        || BarMove.Dead == true || Clear.StageClear == true)
        {
            Particle.SetActive(true);
            JoySticks.SetActive(false);
        }

    }

    public void OnStart()
    {
        TitleUI.SetActive(false);
        OnOff.SetActive(true);
    }

    public void OnReturnStart()
    {
        TitleUI.SetActive(true);
        OnOff.SetActive(false);

    }
    //開始前のアイテム使用.
    public void OnUseItemsOK()
    {
        //使用確定したアイテムを消費する.
        SaveLocalData("ScoreItemData.txt", ref ItemProc.ScoreUP_I);
        SaveLocalData("TimeBonusItemData.txt", ref ItemProc.TimeBonudUP_I);

        PlayUI.SetActive(true);
        JoySticks.SetActive(true);

        Particle.SetActive(false);
        BallMove.BallMoveStart = true;
        OnOff.SetActive(false);
    }
    //同じシーンの頭へ返す.
    public void OnReturn()
    {
        FadeProc.FadeInNeRet = true;
        SceneNo = SceneManager.GetActiveScene().buildIndex;
        inShopSceneNo = SceneManager.GetActiveScene().buildIndex;
        SaveLocalData("SceneNoData.txt", ref SceneNo);
    }

    //最初のステージへ戻す.
    public void OnFirst()
    {
        FadeProc.FadeInNeRet = true;
        SceneNo = SceneLow;
        inShopSceneNo = SceneManager.GetActiveScene().buildIndex;
        BossAttack.BossBattle = false;
        SaveLocalData("SceneNoData.txt", ref SceneNo);
    }

    //次のステージへ進む.
    public void OnNext()
    {
        FadeProc.FadeInNeRet = true;
        SceneNo = SceneManager.GetActiveScene().buildIndex + 1;
        inShopSceneNo = SceneManager.GetActiveScene().buildIndex;
        SaveLocalData("SceneNoData.txt", ref SceneNo);
    }

    /***********オーバーメニュー用**********/
    //ハイスコアのリセット.
    public void OnReset()
    {
        ScoreProc.ReportScore = 0;
        ScoreProc.HighScore = 0;
        SaveLocalData("HighScoreData.txt", ref ScoreProc.ReportScore);

        OffHighScoredesu.SetActive(false);
    }

    //ステージセレクト用.
    public void OnStageSelect(int SelectNo)
    {
        SceneNo = SelectNo;
        FadeProc.FadeInSelect = true;
    }

    //ボタン用(メニューOn/Off).
    public void OnOffTwinOpen()
    {
        OnOff2.SetActive(true);
        OnOff.SetActive(false);
    }

    public void OnOffTwinClose()
    {
        OnOff.SetActive(true);
        OnOff2.SetActive(false);
    }

    //閉じた時の初期化用.
    public void ResetMenu()
    {
        //OnOff.SetActive(true);
        TitleUI.SetActive(false);       //流用(ステージ選択).
    }

    //お遊び.
    public void OnHardMode()
    {
        TouchCnt++;
        SESource.PlayOneShot(SE_LevelUp);

        if (TouchCnt == 3)
        {
            BallMove.Magnification = 2;
            GoalGuardBlock.SetActive(false);
        }
        else if(TouchCnt == 4)
        {
            BallMove.speed = 360;
            BallMove.Magnification = 3;
        }
    }


    /************************ショップ関連****************************/
    //アイテム購入用.
    //未実装のためメッセージのみ表示する.
    public void InShop()
    {
        FadeProc.FadeInShop = true;
    }

    public void OutShop()
    {
        FadeProc.FadeStart = true;
    }

    //ショップの購入ボタン.
    //一つ買うたび情報の更新を行い、記録する(未実装).
    public void GetScoreUP()
    {
        if (300 <= MoneyProc.SocreMoney && 0 <= MoneyProc.SocreMoney - 300)
        {
            ItemProc.ScoreUP_I++;
            SESource.PlayOneShot(SE_Buy);
            MoneyProc.SocreMoney = MoneyProc.SocreMoney - 300;
            MoneyProc.BuyMoney = true;
            //ローカルファイルへ書き込み.
            SaveLocalData("ScoreItemData.txt", ref ItemProc.ScoreUP_I);
            SaveLocalData("S_MoneyData.txt", ref MoneyProc.SocreMoney);

        }
        else
        {
            OnOff.SetActive(true);
            SESource.PlayOneShot(SE_BuyError);
        }
    }

    public void GetTimeBonusUP()
    {
        if (500 <= MoneyProc.SocreMoney && 0 <= MoneyProc.SocreMoney - 500)
        {
            ItemProc.TimeBonudUP_I++;
            SESource.PlayOneShot(SE_Buy);
            MoneyProc.SocreMoney = MoneyProc.SocreMoney - 500;
            MoneyProc.BuyMoney = true;
            //ローカルファイルへ書き込み.
            SaveLocalData("TimeBonusItemData.txt", ref ItemProc.TimeBonudUP_I);
            SaveLocalData("S_MoneyData.txt", ref MoneyProc.SocreMoney);
        }
        else
        {
            OnOff.SetActive(true);
            SESource.PlayOneShot(SE_BuyError);
        }
    }

    /*************************************************************/

    /*オブジェクトの表示非表示切り替え*/
    public void OnOffOpen()
    {
        OnOff.SetActive(true);
    }

    public void OnOffClose()
    {
        OnOff.SetActive(false);
    }


    /*************************************************************/

    //ローカルデータに書き込みを行う汎用関数.
    void SaveLocalData(string txtName, ref int SaveData)
    {
        ExPortData.SaveText(ExPortData.GetInternalStoragePath(),
            txtName,
            SaveData.ToString());
    }

    void LoadLocalData(string txtName, ref int SaveData)
    {

    }
}