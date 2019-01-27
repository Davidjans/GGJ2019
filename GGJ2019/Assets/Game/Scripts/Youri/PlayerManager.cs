﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Attacking,
    Dying
};

public class PlayerManager : MonoBehaviour
{
	private PlayerState m_PlayerState;

    private float m_Health;
    public float m_Money;

    EditorManager m_EM;

    private float m_Timer;

    void Start()
    {
        m_PlayerState = PlayerState.Idle;
        m_EM = GameObject.FindGameObjectWithTag("Manager").GetComponent<EditorManager>();

        m_Health = 100;
        m_Money = 200;
        m_Timer = 0;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && m_EM.m_InEditorMode == false)
        {
            m_PlayerState = PlayerState.Attacking;
        }

        if(m_PlayerState == PlayerState.Attacking)
        {
            m_Timer += Time.deltaTime;
            if(m_Timer >= 1)
            {
                m_PlayerState = PlayerState.Idle;
                m_Timer = 0;
            }
        }
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

    public PlayerState GetPlayerState()
    {
        return m_PlayerState;
    }

    public void SetPlayerState(PlayerState state)
    {
        m_PlayerState = state;
    }
}
