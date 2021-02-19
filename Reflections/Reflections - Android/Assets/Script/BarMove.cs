using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarMove : MonoBehaviour
{
    //pub.
    public GameObject L_Wall;
    public GameObject R_Wall;
    public GameObject U_Wall;
    public GameObject D_Wall;
    public GameObject BossRoom_Wall;

    public DynamicJoystick joystick;

    public bool test1;
    public bool test2;
    //public FloatingJoystick joystick;
    //public VariableJoystick joystick;

    //pri.

    //pub sta.
    public static bool Dead;
    public static bool ClearStop;

    //Local.
    float x, z;
    bool CollHit;


    void Start()
    {
        Dead = false;
        ClearStop = false;
    }

    void Update()
    {
        //移動制限：(制限したいオブジェクトの座標,座標の最小値,最大値);.
        if(BossAttack.BossBattle == false)
        {
            this.transform.position = (
            new Vector3(Mathf.Clamp(this.transform.position.x, L_Wall.transform.position.x + 5.0f, R_Wall.transform.position.x - 5.0f),
                        this.transform.position.y,
                       Mathf.Clamp(this.transform.position.z, D_Wall.transform.position.z, U_Wall.transform.position.z)));
        }
        else
        {
            this.transform.position = (
            new Vector3(Mathf.Clamp(this.transform.position.x, L_Wall.transform.position.x + 5.0f, R_Wall.transform.position.x - 5.0f),
                                    this.transform.position.y,
                                   Mathf.Clamp(this.transform.position.z, BossRoom_Wall.transform.position.z + 5.0f, U_Wall.transform.position.z)));
        }

        if (Dead == true || ClearStop == true)
        {
            x = 0.0f;
            z = 0.0f;
        }
        else
        {
            x = joystick.Horizontal;
            z = joystick.Vertical;
        }
        transform.position += new Vector3(x, 0, z);
    }


    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        { this.transform.Translate(-0.5f, 0f, 0f); }

        if (Input.GetKey(KeyCode.RightArrow))
        { this.transform.Translate(0.5f, 0f, 0f);  }

        if (Input.GetKey(KeyCode.UpArrow))
        { this.transform.Translate(0f, 0.5f, 0f);  }

        if (Input.GetKey(KeyCode.DownArrow))
        { this.transform.Translate(0f, -0.5f, 0f);　}
    }

}
