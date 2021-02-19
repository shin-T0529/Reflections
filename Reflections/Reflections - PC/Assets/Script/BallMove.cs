using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    //pub.
    public bool GameStart;

    public AudioClip SE_Wall;
    public AudioClip SE_Block;
    public AudioClip SE_Shpere;
    public AudioClip SE_Player;
    public AudioClip SE_Enemy_A;
    public AudioClip SE_Enemy_B;
    public AudioClip SE_BossHit;

    //pri.
    private AudioSource SESource;

    //pub sta.
    static public float speed = 200;
    static public bool BallMoveStart;
    static public int Magnification = 1;
    //Local.
    Rigidbody rb;


    void Start()
    {
        speed = 170;
        GameStart = false;
        BallMoveStart = false;
        Magnification = 1;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        BossProc.BossDead = false;

        SESource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(BallMoveStart == true && GameStart == false)
        {
            // rigidbodyを取得
            rb = this.GetComponent<Rigidbody>();        // 力を設定
            Vector3 force = new Vector3(0.0f, 0.0f, -10.0f) * speed;
            // 力を加える
            rb.AddForce(force);
            GameStart = true;
        }

        //減速した時のために微加速を行い、調整をかける.
        if (rb.velocity.magnitude < 34f)
        {
            Vector3 force = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z) * speed / 3;
            rb.velocity = Vector3.zero;     //力を加える前に一度代入初期化.
            //力を加える.
            rb.AddForce(force);
        }

        //ボスを倒した後玉の動きを止める.
        if (BossProc.BossDead == true)
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //基本スコア*ハードモード増加分*スコアアイテム使用分.
        if (collision.gameObject.tag == "Wall")
        {
            ScoreProc.Score += 10 * Magnification * (ItemProc.ScoreUP_mag + 1);
            SESource.PlayOneShot(SE_Wall);
        }

        if (collision.gameObject.tag == "Block")
        {
            ScoreProc.Score += 50 * Magnification * (ItemProc.ScoreUP_mag + 1);
            SESource.PlayOneShot(SE_Block);
        }

        if (collision.gameObject.tag == "Shp")
        {
            ScoreProc.Score += 100 * Magnification * (ItemProc.ScoreUP_mag + 1);
            SESource.PlayOneShot(SE_Shpere);
        }

        if (collision.gameObject.tag == "Enemy_A")
        {
            ScoreProc.Score += 80 * Magnification * (ItemProc.ScoreUP_mag + 1);
            SESource.PlayOneShot(SE_Enemy_A);
        }

        if (collision.gameObject.tag == "Enemy_B")
        {
            ScoreProc.Score += 80 * Magnification * (ItemProc.ScoreUP_mag + 1);
            SESource.PlayOneShot(SE_Enemy_B);
        }

        if (collision.gameObject.tag == "Boss")
        {
            ScoreProc.Score += 100 * Magnification * (ItemProc.ScoreUP_mag + 1);
            SESource.PlayOneShot(SE_BossHit);
        }

        if (collision.gameObject.tag == "Player")
        {
            SESource.PlayOneShot(SE_Player);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Goal"))
        { Clear.BlockGoal = true; }

        if (collider.CompareTag("DeadGoal"))
        { Clear.BlockDead = true; }
    }
}
