using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeProc : MonoBehaviour
{
    //pub.
    public Image Fade;
    public GameObject FadeCanvas;
    public float speed = 0.01f;                     //透明化の速さ.

    //pri.

    //pub sta.
    public static bool FadeStart, Fadeend;          //ショップから出るとき.
    public static bool FadeInShop, FadeOutShop;     //ショップに入るとき.
    public static bool FadeInSelect, FadeOutSelect; //ステージセレクトで選択したとき.
    public static bool FadeInNeRet, FadeOutNeRet;   //次、戻るかを選択したとき.

    //Local.
    float alfa;                                     //A値を操作するための変数.
    float red, green, blue;                         //RGBを操作するための変数.


    void Start()
    {
        FadeStart = Fadeend = false;
        FadeInShop = FadeOutShop = false;
        FadeInSelect = FadeOutSelect = false;
        FadeInNeRet = FadeOutNeRet = false;

        red = Fade.GetComponent<Image>().color.r;
        green = Fade.GetComponent<Image>().color.g;
        blue = Fade.GetComponent<Image>().color.b;

    }

    // Update is called once per frame
    void Update()
    {
        FadeMain(ref ButtonProc.inShopSceneNo, ref ButtonProc.SceneNo);
    }

    void FadeMain(ref int OutSceneNo , ref int SceneNo)
    {
        if (FadeStart == true || FadeInShop == true || FadeInSelect == true || FadeInNeRet == true)
        {
            FadeCanvas.SetActive(true);
            Fade.enabled = true;
            Fade.GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;

            ChangeJumpFlag(FadeStart, ref Fadeend);
            ChangeJumpFlag(FadeInShop, ref FadeOutShop);
            ChangeJumpFlag(FadeInSelect, ref FadeOutSelect);
            ChangeJumpFlag(FadeInNeRet, ref FadeOutNeRet);

        }

        if (Fadeend == true)
        {
            //元いたシーンに帰る.
            SceneManager.LoadScene(OutSceneNo);
        }
        else if(FadeOutShop == true)
        {
            //元いたシーンに帰れるようにする.
            OutSceneNo = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("6_SHOP");
        }
        else if(FadeOutSelect == true)
        {   //ロード画面を挟んで選択したシーンへ移動.
            SceneManager.LoadScene("0_Loading");
        }
        else if (FadeOutNeRet == true)
        {   //ロード画面を挟んで選択したシーンへ移動.
            SceneManager.LoadScene(SceneNo);
        }

    }

    void ChangeJumpFlag(bool Start,ref bool End)
    {

        if (1.1f < alfa && Start == true)
        {
            alfa = 1.0f;
            End = true;
        }

    }
}
