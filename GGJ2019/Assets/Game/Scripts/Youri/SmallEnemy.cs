using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SmallEnemy : Enemy
{    

    private void Update()
    {
        if (m_IsRooted == false)
        {
            Move();
        }
        else
        {
            m_RootTimer += Time.deltaTime;
            if (m_RootTimer >= m_RootTime)
            {
                m_IsRooted = false;
            }
        }

        if (m_WithinAttackDistance == true)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        m_AttackTimer += Time.deltaTime;

        if (m_AttackTimer >= 0.5)
        {
            m_PlayerManager.TakeDamage(15);
            m_AttackTimer = 0;
        }
    }
}
