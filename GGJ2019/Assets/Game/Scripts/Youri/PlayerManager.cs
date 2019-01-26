using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walking,
    Attacking,
    Dying
};

public class PlayerManager : MonoBehaviour
{
    private PlayerState m_PlayerState;

    private float m_Health;
    private float m_Money;
    private float m_Cost;

    void Start()
    {
        m_Health = 100;
        m_Money = 200;
    }

    public void TakeDamage(float value)
    {
        m_Health -= value;
    }

    public void AddMoney(float value)
    {
        m_Money += value;
    }

    public void SpendMoney(float cost)
    {
        m_Cost = cost;
        if(m_Money >= m_Cost)
        {
            m_Money -= m_Cost;
            
        }
        else
        {
            
        }
    }
}
