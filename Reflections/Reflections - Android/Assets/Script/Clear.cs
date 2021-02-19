using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    //pub.
    public GameObject ClearUI;
    public GameObject GameOverUI;
    public GameObject ReturnButton;
    public GameObject RetryButton;
    public GameObject NextButton;

    public GameObject BossHP;

    public AudioClip SE_FanFale;
    public AudioClip SE_DeadGoal;

    //pri.
    private AudioSource SESource;

    //pub sta.
    public static bool BlockGoal;   //直接操作したい.
    public static bool BlockDead;   //直接操作したい.
    public static bool StageClear;
    //Local.
    GameObject obj;
    int count;
    int count1;

    void Start()
    {
        count = 0;
        count1 = 0;
        BlockGoal = BlockDead = StageClear = false;
        obj = GameObject.Find("Ball");  //対象オブジェクトを検索、代入.
        SESource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ClearCheck();
        OverCheck();

    }

    void ClearCheck()
    {
        //上部壁に当たった時.
        if (BlockGoal == true || StageClear == true)
        {
            if(count < 3 && BossAttack.BossBattle == false)
            {
                count++;
                SESource.PlayOneShot(SE_FanFale);
            }
            if (count < 7 && BossAttack.BossBattle == true)
            {
                count++;
                SESource.PlayOneShot(SE_FanFale);
                BossHP.SetActive(false);
            }

            BarMove.ClearStop = true;
            ClearUI.SetActive(true);
            NextButton.SetActive(true);
            ReturnButton.SetActive(true);
            Destroy(obj);
        }

    }

    void OverCheck()
    {
        //下部壁に当たった時.
        if (BlockDead == true || BarMove.Dead == true)
        {
            if (count1 < 1)
            {
                count1++;
                SESource.PlayOneShot(SE_DeadGoal);
            }
            GameOverUI.SetActive(true);
            RetryButton.SetActive(true);
            if (BossAttack.BossBattle == true)
            {
                BossHP.SetActive(false);
            }
            Destroy(obj);
        }

    }
}

