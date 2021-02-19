using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWall : MonoBehaviour
{
    //pub
    public GameObject SetRandamWall_1;
    public GameObject SetRandamWall_2;
    public GameObject SetRandamWall_3;

    public float SetX0_1, SetZ0_1;
    public float SetX1_1, SetZ1_1;
    public float SetX1_2, SetZ1_2;
    public float SetX1_3, SetZ1_3;

    public float SetY = 4.420233f;

    //pri

    //pub sta


    //local
    int SetPosNo;

    void Start()
    {
        SetPosNo = 0;
        SetPosNo = Random.Range(0, 3);
        SetWallPos(SetPosNo);
    }

    void Update()
    {
        
    }

    void SetWallPos(int SetNo)
    {
        switch(SetNo)
        {
            case 0:
                if(SetRandamWall_1 != null)
                {
                    SetRandamWall_1.transform.position = new Vector3(SetX0_1, SetY, SetZ0_1);
                }
                if (SetRandamWall_2 != null)
                {

                }
                if (SetRandamWall_3 != null)
                {

                }
                break;
            case 1:
                if (SetRandamWall_1 != null)
                {
                    SetRandamWall_1.transform.position = new Vector3(SetX1_1, SetY, SetZ1_1);
                }
                if (SetRandamWall_2 != null)
                {

                }
                if (SetRandamWall_3 != null)
                {

                }
                break;
            case 2:
                if (SetRandamWall_1 != null)
                {
                    SetRandamWall_1.transform.position = new Vector3(SetX1_2, SetY, SetZ1_2);
                }
                if (SetRandamWall_2 != null)
                {

                }
                if (SetRandamWall_3 != null)
                {

                }
                break;
            case 3:
                if (SetRandamWall_1 != null)
                {
                    SetRandamWall_1.transform.position = new Vector3(SetX1_3, SetY, SetZ1_3);
                }
                if (SetRandamWall_2 != null)
                {

                }
                if (SetRandamWall_3 != null)
                {

                }
                break;
            default:
                break;
        }
    }
}
