using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarColl : MonoBehaviour
{
    //pub.
    public Image HPBarin;
    public Image HPBar;

    public AudioClip SE_Dead;
    public AudioClip SE_Hit;

    public AnimationClip Hit;
    public AnimationClip Dead;

    //pri.
    private float DamageSpeed;      //HP減少速度.
    private float currentDamage;    //内部計算用.
    private float MaxDamage;        //受けるダメージ.

    private AudioSource SESource;

    //pub sta.

    //Local.
    int AnimState;
    bool CollHit;
    Animation Anim;
    MeshRenderer meshRenderer;

    void Start()
    {
        AnimState = 0;
        DamageSpeed = 0.005f;
        currentDamage = 0.0f;
        Anim = this.gameObject.GetComponent<Animation>();
        meshRenderer = this.GetComponent<MeshRenderer>();

    }

    void Update()
    {
        HPProc();
        AnimStateChange(AnimState);
        SESource = GetComponent<AudioSource>();
    }

    //HP減少処理.
    void HPProc()
    {
        if (CollHit == true)
        {
            if (currentDamage < MaxDamage && HPBarin.fillAmount != 0.0f)
            {
                HPBarin.fillAmount -= DamageSpeed; //HPの計算.
                currentDamage += 0.005f;        //徐々に減らすため加算していく.
                AnimState = 1;
            }
            else
            {
                Anim.Stop();
                AnimState = 0;
                currentDamage = 0.0f;
                MaxDamage = 0.0f;
                meshRenderer.enabled = true;
                CollHit = false;
            }

        }

        //体力が無くなった場合.
        if (HPBarin.fillAmount <= 0.0f)
        {
            if (this.gameObject.GetComponent<BoxCollider>().enabled == true)
            {
                BallMove.BallMoveStart = false;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                SESource.PlayOneShot(SE_Dead);
            }
            AnimState = 2;
            BarMove.Dead = true;
        }
    }

    void PlayerHitProc()
    {
        meshRenderer.enabled = true;
        AnimState = 0;
    }

    void PlayerDeadProc()
    {
        HPBar.enabled = false;
        HPBarin.enabled = false;

        this.gameObject.SetActive(false);
    }

    void AnimStateChange(int i)
    {
        switch (i)
        {
            case 0:
                        //通常状態.
                break;
            case 1:     //被弾時.
                Anim.clip = Hit;
                if (CollHit == true)
                {
                    Anim.Play();
                }
                break;
            case 2:     //死亡.
                Anim.clip = Dead;
                Anim.Play();
                break;
            default:
                Anim.Stop();
                break;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(CollHit == false)
        {
            if (collider.CompareTag("E_Coll"))
            {
                CollHit = true;
                MaxDamage = 0.1f;
                SESource.PlayOneShot(SE_Hit);
                Debug.Log("Hit!");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BossBullet")
        {
            CollHit = true;
            MaxDamage = 0.2f;
            SESource.PlayOneShot(SE_Hit);
            Debug.Log("BossBulletHit!");
        }
    }

}
