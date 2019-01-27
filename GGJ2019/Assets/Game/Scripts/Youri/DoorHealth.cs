using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHealth : MonoBehaviour
{
	public float m_MaxHealth;
    public float m_Health;

    void Start()
    {
		m_Health = m_MaxHealth;
    }

    void Update()
    {
        if(m_Health <= 0)
        {
			SceneManager.LoadScene("DoorDown");
        }
    }

    public void TakeDamage(float value)
    {
        m_Health -= value;
    }
}
