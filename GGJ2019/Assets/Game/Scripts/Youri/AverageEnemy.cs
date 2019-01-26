﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class AverageEnemy : Enemy
{
    [SerializeField]
    private GameObject m_Spit;

    private void Update()
    {
        if(m_IsRooted == false)
        {
            Move();
        }
        else
        {
            m_RootTimer += Time.deltaTime;
            if(m_RootTimer >= m_RootTime)
            {
                m_IsRooted = false;
            }
        }

        if(m_WithinAttackDistance == true)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        m_AttackTimer += Time.deltaTime;
        Debug.Log(m_AttackTimer);
        if (m_AttackTimer >= 1)
        {
            GameObject go = Instantiate(m_Spit, transform.position, Quaternion.identity);
            Spit spit = go.GetComponent<Spit>();
            spit.SetDirection(m_Player.transform.position - transform.position);
            m_AttackTimer = 0;
        }
    }
}

public interface IEnemy
{
    void Move();
    void Attack();
    void Die();
}
