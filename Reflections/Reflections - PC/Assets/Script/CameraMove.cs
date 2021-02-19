using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //pub.
    public Transform m_target = null;
    public float m_speed = 5;
    public float m_attenuation = 0.5f;  //減衰.

    //pri.
    private Vector3 m_velocity;

    //pub sta.

    //Local.


    void Start()
    {
        
    }

    void Update()
    {
        m_velocity.z += (m_target.position.z - transform.position.z) * m_speed;
        m_velocity.z *= m_attenuation;
        transform.position += m_velocity *= Time.deltaTime;
    }
}
