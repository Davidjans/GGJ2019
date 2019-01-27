﻿using System.Collections;
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

	public float m_MaxHealth;
	public float m_Health;
	
	public float m_Money;

    EditorManager m_EM;

    void Start()
    {
		m_Health = m_MaxHealth;
		m_EM = GameObject.FindGameObjectWithTag("Manager").GetComponent<EditorManager>();
        m_Money = 200;
    }

    private void Update()
    {
        
    }

    public void TakeDamage(float value)
    {
        m_Health -= value;
    }

    public void AddMoney(float value)
    {
        m_Money += value;
    }

    public void PurchaseTrap(float cost)
    {
        m_Money -= cost;
    }
}
