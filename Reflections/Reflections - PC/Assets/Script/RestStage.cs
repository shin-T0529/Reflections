using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestStage : MonoBehaviour
{
    public GameObject StageButton_1;
    public GameObject StageButton_2;
    public GameObject StageButton_3;
    public GameObject StageButton_4;

    //Local.
    int SetRestNo;

    void Start()
    {
        SetRestNo = 0;
        StageButton_1.SetActive(false);
        StageButton_2.SetActive(false);
        StageButton_3.SetActive(false);
        StageButton_4.SetActive(false);

    }

    void Update()
    {
        SetRestNo = ButtonProc.SceneNo;
        SetRestStage(SetRestNo);
    }

    void SetRestStage(int SetNo)
    {
        switch(SetNo)
        {
            case 0:
                StageButton_1.SetActive(true);
                break;
            case 1:
                StageButton_1.SetActive(true);
                break;
            case 2:
                StageButton_1.SetActive(true);
                StageButton_2.SetActive(true);
                break;
            case 3:
                StageButton_1.SetActive(true);
                StageButton_2.SetActive(true);
                StageButton_3.SetActive(true);
                break;
            case 4:
                StageButton_1.SetActive(true);
                StageButton_2.SetActive(true);
                StageButton_3.SetActive(true);
                StageButton_4.SetActive(true);
                break;
            case 5:
                break;

            default:
                break;
        }
    }
}
