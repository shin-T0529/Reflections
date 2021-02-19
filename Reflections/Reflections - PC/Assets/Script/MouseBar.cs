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

    public GameObject BasePlayer;
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;


    void Update()
    {
        //this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        //Vector3 BarPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //transform.position = Camera.main.ScreenToWorldPoint(BarPos);

        //移動制限：(制限したいオブジェクトの座標,座標の最小値,最大値);.
        this.transform.position = (
        new Vector3(Mathf.Clamp(this.transform.position.x, L_Wall.transform.position.x + 5.0f, R_Wall.transform.position.x - 5.0f),
                    this.transform.position.y,
                   Mathf.Clamp(this.transform.position.z, D_Wall.transform.position.z, U_Wall.transform.position.z)));

    }

    void OnMouseDrag()
    {
        Vector3 screenPosition = Input.mousePosition;
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        screenPosition.z = screenPoint.z - 5.0f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosition.y = 4.68f;        //座標のズレを無くすために固定する.
        BasePlayer.transform.position = worldPosition;
    }
}
 