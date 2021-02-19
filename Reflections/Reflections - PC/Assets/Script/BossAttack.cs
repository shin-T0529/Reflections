using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttack : MonoBehaviour
{
    //pub.
    public GameObject BossBox;
    public GameObject BossRoomWall;

    public GameObject BossCenter;
    public GameObject BossBullet;

    public GameObject BossHPBack;

    public int PatternSet;


    //pri.
    //private AudioSource SESource;

    //pub sta.
    public static bool BossBattle;

    //Local.
    bool Attack;
    int AttackCnt;
    int AttackNo;
    Vector3 force;

    void Start()
    {
        PatternSet = 0;
        AttackCnt = 0;
        Attack = false;
        BossBattle = false;
    }

    void Update()
    {
        if(BossBox.activeSelf)
        {
            BossBattle = true;
            BossRoomWall.SetActive(true);
            BossHPBack.SetActive(true);
            if (200 < AttackCnt)
            {
                AttackNo = 2;
            }
            else if (100 < AttackCnt)
            {
                AttackNo = 1;
            }
            else if (AttackCnt < 100)
            {
                AttackNo = 0;
            }
            BossAttackNo(ref AttackNo);
        }
        else
        {
            Attack = false;
            AttackNo = 0;
        }
    }


    void BossAttackNo(ref int i)
    {
        switch(i)
        {
            case 0:
                AttackCnt++;
                break;
            case 1:
                AttackCnt++;

                if (Attack == false)
                {
                    PatternSet = Random.Range(1, 4);

                    //とりあえず1つずつ3方向に飛ばす.
                    if (PatternSet == 1)
                    {
                        CreateBullet(45,-15.0f,-15.0f);
                    }
                    if (PatternSet == 2)
                    {
                        CreateBullet(135, 15.0f, -15.0f);
                    }
                    if (PatternSet == 3)
                    {
                        CreateBullet(0, 0.0f, -15.0f);
                    }
                    Attack = true;
                }
                break;
            case 2:
                    AttackCnt = 0;
                    Attack = false;
                    i = 0;
                break;
        }
    }

    void CreateBullet(float RoteY,float ribx,float ribz)
    {
        //コピーオブジェクト：座標：回転値.
        GameObject Bullet = Instantiate(BossBullet, new Vector3(2.0f, 2.0f, -5.0f),
            Quaternion.Euler(0, RoteY, 0));
        Rigidbody rib = Bullet.GetComponent<Rigidbody>();
        force = new Vector3(ribx, 0.0f, ribz) * 94;
        rib.AddForce(force);
        //ボスの真ん中から射出する.
        Bullet.transform.position = BossCenter.transform.position;
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            BossBox.SetActive(true);
        }
    }
}
