using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossProc : MonoBehaviour
{
    //pub.
    public GameObject Boss;
    public GameObject BossBox;
    public GameObject Ball;
    public Animation BossAnim;

    public AnimationClip Dead;

    public int AnimationNo;

    public Image BossHP;
    //pri.
    //private AudioSource SESource;
    private float DamageSpeed;      //HP減少速度.
    private float currentDamage;    //内部計算用.
    private float MaxDamage;        //受けるダメージ.

    //pub sta.
    public static bool BossDead;
    //Local.
    bool BossHit;

    void Start()
    {
        BossDead = false;
        DamageSpeed = 0.005f;
        //SESource = GetComponent<AudioSource>();
        BossAnim = this.gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        HPProc();
        MoveState(AnimationNo);
    }

    void MoveState(int i)
    {
        switch (i)
        {
            case 0:
                break;
            case 1:
                BossAnim.clip = Dead;
                BossAnim.Play();
                break;
            default:
                BossAnim.Stop();
                break;
        }
    }

    void HPProc()
    {
        if (BossHit == true)
        {
            if (currentDamage < MaxDamage && BossHP.fillAmount != 0.0f)
            {
                BossHP.fillAmount -= DamageSpeed; //HPの計算.
                currentDamage += 0.005f;        //徐々に減らすため加算していく.
            }
            else
            {
                currentDamage = 0.0f;
                MaxDamage = 0.0f;
                BossHit = false;
            }
        }

        //HPが0になったとき.
        if (BossHP.fillAmount <= 0.0f)
        {
            if (this.gameObject.GetComponent<BoxCollider>().enabled == true)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                //SESource.PlayOneShot(SE_EDead);

                //ボールの動きを止める.
                Rigidbody rb = Ball.GetComponent<Rigidbody>();
                //動く反対方向に力を加えて止める.
                Vector3 force = new Vector3(0.0f, 0.0f, 10.0f) * BallMove.speed;
                rb.AddForce(force);
            }
            BarMove.ClearStop = true;
            BossDead = true;
            AnimationNo = 1;
        }

    }

    void BossDeadProc()
    {
        Clear.StageClear = true;
        Boss.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            BossHit = true;
            MaxDamage = 0.12f;
            Debug.Log("残りボス体力:" + BossHP.fillAmount);
        }
    }
}
