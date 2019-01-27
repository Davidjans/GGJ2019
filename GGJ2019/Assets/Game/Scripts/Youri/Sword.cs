using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerManager m_PlayerManager;
    private Animator m_Animator;

    private PlayerState m_PlayerState;

    void Start()
    {
        m_PlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        m_PlayerState = m_PlayerManager.GetPlayerState();

        m_Animator.SetInteger("PlayerState", (int)m_PlayerState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(5f);
        }
    }
}
