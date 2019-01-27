using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHealth : MonoBehaviour
{
    private float m_Health;

    void Start()
    {
        
    }

    void Update()
    {
        if(m_Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float value)
    {
        m_Health -= value;
    }
}
