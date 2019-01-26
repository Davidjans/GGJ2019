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

    private bool m_CanPurchase;

    EditorManager m_EM;

    void Start()
    {
        m_EM = GameObject.FindGameObjectWithTag("Manager").GetComponent<EditorManager>();

        m_Health = 100;
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
        
    }
}
