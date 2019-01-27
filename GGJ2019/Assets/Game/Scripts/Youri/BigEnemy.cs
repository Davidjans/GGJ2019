using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    public override void Update()
    {
        base.Update();

        if (m_IsRooted == false && m_IsStunned == false)
        {
            Move();
        }
        else if (m_IsRooted == true && m_IsStunned == false)
        {
            m_RootTimer += Time.deltaTime;
            if (m_RootTimer >= m_RootTime)
            {
                m_IsRooted = false;
            }
        }
        else if (m_IsRooted == false && m_IsStunned == true)
        {
            m_RootTimer += Time.deltaTime;
            if (m_RootTimer >= 2)
            {
                m_IsStunned = false;
            }
        }

        if (m_WithinAttackDistance == true)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        m_EnemyState = EnemyState.Attacking;
        m_AttackTimer += Time.deltaTime;
       
        if (m_AttackTimer >= 3)
        {
            m_PlayerManager.TakeDamage(30);
            m_AttackTimer = 0;
        }
    }
}
