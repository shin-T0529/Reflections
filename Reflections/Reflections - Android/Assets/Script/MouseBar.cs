using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBar : MonoBehaviour
{
    Vector3 screenPoint;

    public GameObject L_Wall;
    public GameObject R_Wall;
    public GameObject U_Wall;
    public GameObject D_Wall;

    // Update is called once per frame
    void Update()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 BarPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        transform.position = Camera.main.ScreenToWorldPoint(BarPos);

        //移動制限：(制限したいオブジェクトの座標,座標の最小値,最大値);.
        this.transform.position = (
        new Vector3(Mathf.Clamp(this.transform.position.x, L_Wall.transform.position.x + 5.0f,R_Wall.transform.position.x),
                               Mathf.Clamp(this.transform.position.y, D_Wall.transform.position.y, U_Wall.transform.position.y),
                                this.transform.position.z));

    }
}
