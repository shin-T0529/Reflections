using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class ItemProc : MonoBehaviour
{
    //pub
    public GameObject ErrorNotUsed;                //ウィンドウ表示(UIで今はしている).
    public GameObject ErrorNotHaving;

    public string inDataItem = string.Empty;
    public Text ScoreHave;
    public Text ScoreUse;
    public Text TimeHave;
    public Text TimeUse;

    public AudioClip SE_ItemUse;
    public AudioClip SE_ItemUseError;
    public AudioClip SE_ItemUseReset;

    //pri
    private AudioSource SESource;

    //pub sta
    public static int ScoreUP_I = 0;        //スコア加算用アイテム.
    public static int TimeBonudUP_I = 0;    //タイムボーナス加算用アイテム.
    public static int ScoreUP_mag;          //使用時の加算倍率の設定.
    public static int TimeBonudUP_mag;      //タイムボーナス獲得までの時間設定増加.

    public static int useItem;              //アイテム使用上限設定数(共通項かつ1つしか存在しない).

    //local

    void Start()
    {
        //バグ防止用.
        ScoreUP_I = 0;
        TimeBonudUP_I = 0;

        //アイテム所持数の読み込み.
        ExPortData.Loadtext(ExPortData.GetInternalStoragePath(),
            "ScoreItemData.txt",
            inDataItem, ref ScoreUP_I);
        Debug.Log(ScoreUP_I);


        ExPortData.Loadtext(ExPortData.GetInternalStoragePath(),
            "TimeBonusItemData.txt",
            inDataItem, ref TimeBonudUP_I);
        Debug.Log(TimeBonudUP_I);

        ScoreUP_mag = 0;
        TimeBonudUP_mag = 0;

        useItem = 0;

    }


    void Update()
    {
        //各アイテムの所持数と使用数.
        ScoreHave.text = "所持数: " + ScoreUP_I;
        ScoreUse.text = "使った数: " + ScoreUP_mag;
        TimeHave.text = "所持数: " + TimeBonudUP_I;
        TimeUse.text = "使った数: " + TimeBonudUP_mag;

    }

    /*アイテム使用時倍率設定用*/
    public void UseScore()
    {
        SESource = GetComponent<AudioSource>();

        if (0 < ScoreUP_I && useItem < 5)
        {
            ScoreUP_I--;
            ScoreUP_mag++;
            useItem++;
            SESource.PlayOneShot(SE_ItemUse);
            Debug.Log("スコアアイテム使用数： " + ScoreUP_mag);
            Debug.Log("上限 " + useItem);

        }
        else if (5 <= useItem)
        {
            SESource.PlayOneShot(SE_ItemUseError);
            ErrorNotUsed.SetActive(true);
        }
        else if (ScoreUP_I <= 0)
        {
            SESource.PlayOneShot(SE_ItemUseError);
            ErrorNotHaving.SetActive(true);
        }
    }

    public void UseTime()
    {
        SESource = GetComponent<AudioSource>();

        if (0 < TimeBonudUP_I && useItem < 5)
        {
            TimeBonudUP_I--;
            TimeBonudUP_mag++;
            useItem++;
            SESource.PlayOneShot(SE_ItemUse);
            Debug.Log("タイムアイテム使用数： " + TimeBonudUP_mag);
            Debug.Log("上限 " + useItem);

        }
        else if (5 <= useItem)
        {
            SESource.PlayOneShot(SE_ItemUseError);
            ErrorNotUsed.SetActive(true);
        }
        else if(TimeBonudUP_I <= 0)
        {
            SESource.PlayOneShot(SE_ItemUseError);
            ErrorNotHaving.SetActive(true);
        }
    }

    public void useItemReset()
    {
        SESource = GetComponent<AudioSource>();

        ScoreUP_I = ScoreUP_I + ScoreUP_mag;
        TimeBonudUP_I = TimeBonudUP_I + TimeBonudUP_mag;
        ScoreUP_mag = TimeBonudUP_mag = 0;
        useItem = 0;
        SESource.PlayOneShot(SE_ItemUseReset);
    }
}
