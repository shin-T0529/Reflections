using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDes : MonoBehaviour
{

    //pub.
    public int HitCount;
    //pri.

    //pub sta.

    //Local.
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(HitCount == 4 || BossProc.BossDead == true)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Block"
         || collision.gameObject.tag == "Shp")
        {
            HitCount++;
        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ball")
        {
            rb.isKinematic = true;
            //体力減らす処理入れる.
            Destroy(this.gameObject);
        }
    }

}
