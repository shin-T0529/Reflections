using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShopProc : MonoBehaviour
{
    //pub
    public AudioClip SE_Buy;
    public Text HaveItem1;
    public Text HaveItem2;

    public string inDataShop = string.Empty;

    //pri
    private AudioSource SESource;

    //pub sta
    
    //local


    void Start()
    {
        ExPortData.Loadtext(ExPortData.GetInternalStoragePath(),
                            "ScoreItemData.txt",
                            inDataShop, ref ItemProc.ScoreUP_I);


        ExPortData.Loadtext(ExPortData.GetInternalStoragePath(),
                            "TimeBonusItemData.txt",
                            inDataShop, ref ItemProc.TimeBonudUP_I);

        Debug.Log(ItemProc.ScoreUP_I);
        Debug.Log(ItemProc.TimeBonudUP_I);

    }

    void Update()
    {
        HaveItem1.text = "所持数: " + ItemProc.ScoreUP_I;
        HaveItem2.text = "所持数: " + ItemProc.TimeBonudUP_I;

    }
}
