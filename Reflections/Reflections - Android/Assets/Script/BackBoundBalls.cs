using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBoundBalls : MonoBehaviour
{
    //pub.
    public GameObject Ball;     //飛ばすもの.
    public GameObject ShotBallPos; //発射位置.

    public Material[] colors;

    //pri.

    //pub sta.

    //Local.
    int ShotCount;
    int ColorNo;
    float ribx, ribz;           //発射角度を乱数で変更する.
    Vector3 force;
   
    void Start()
    {
        ColorNo = 0;
        ShotCount = 0;
    }

    void Update()
    {
        if(80 < ShotCount)
        {
            ribx = Random.Range(10, 100);
            ribz = Random.Range(10, 100);
            ColorNo = Random.Range(1, 5);
            //コピーオブジェクト：座標：回転値.
            GameObject BackBoundBall = Instantiate(Ball, new Vector3(2.0f, 2.0f, -5.0f),
                Quaternion.Euler(0, 0, 0));
            Rigidbody rib = BackBoundBall.GetComponent<Rigidbody>();
            force = new Vector3(ribx, 0.0f, ribz) * 40;
            rib.AddForce(force);
            BackBoundBall.GetComponent<Renderer>().material.color = colors[ColorNo].color;
            //ボスの真ん中から射出する.
            BackBoundBall.transform.position = ShotBallPos.transform.position;
            ShotCount = 0;
        }
        else
        {
            ShotCount++;
        }

    }
}
