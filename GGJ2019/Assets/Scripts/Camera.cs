using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform m_CameraTransform, m_Character, _CenterPoint;

    private float m_MouseX, m_MouseY;
    public float _MouseSensitivity = 10f;

    private float m_Vertical, m_Horizontal;
    public float m_Movespeed = 5f;

    public float m_Turnspeed = 5;

    private Vector3 m_Movement;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        m_MouseX += Input.GetAxis("Mouse X");
        m_MouseY -= Input.GetAxis("Mouse Y");
         
        m_MouseY = Mathf.Clamp(m_MouseY, -60f, 60f);
        m_CameraTransform.LookAt(_CenterPoint);
        _CenterPoint.localRotation = Quaternion.Euler(m_MouseY, m_MouseX, 0);

        m_Vertical = Input.GetAxis("Vertical") * m_Movespeed;
        m_Horizontal = Input.GetAxis("Horizontal") * m_Movespeed;

        m_Movement = new Vector3(m_Horizontal, 0, m_Vertical);
        m_Movement = m_Character.rotation * m_Movement;
        _CenterPoint.position = new Vector3(m_Character.position.x, m_Character.position.y, m_Character.position.z);

        if (m_Vertical != 0)
        {
            Quaternion turnAngle = Quaternion.Euler(0, _CenterPoint.eulerAngles.y, 0);
            m_Character.rotation = Quaternion.Slerp(m_Character.rotation, turnAngle, Time.deltaTime * m_Turnspeed);
        }
    }

    private void FixedUpdate()
    {
        m_Character.transform.Translate(m_Movement * Time.deltaTime * m_Movespeed);
    }
}
