using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProc: MonoBehaviour
{
    //pub.
    public GameObject M_Enemy;

    public Animation EnemyAnim;

    public AnimationClip Dead;

    public AudioClip SE_EDead;
    public int AnimationNo;
    //pri.
    private AudioSource SESource;

    //pub sta.

    //Local.
    int EnemyHP;
    void Start()
    {
        EnemyHP = 2;
        SESource = GetComponent<AudioSource>();
        EnemyAnim = this.gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        if (EnemyHP <= 0)
        {
            if (this.gameObject.GetComponent<BoxCollider>().enabled == true)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                SESource.PlayOneShot(SE_EDead);
            }
            AnimationNo = 1;
        }

        MoveState(AnimationNo);
    }

    void MoveState(int i)
    {
        switch(i)
        {
            case 0:
                break;
            case 1:     //TypeC.
                EnemyAnim.clip = Dead;
                EnemyAnim.Play();
                break;
            default:
                EnemyAnim.Stop();
                break;
        }
    }

    void EnemyDeadProc()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            EnemyHP -= 1;
            Debug.Log("残り敵体力" + EnemyHP);
        }
    }

}
