using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    public override void Update()
    {
        base.Update();

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
        m_EnemyState = EnemyState.Attacking;
        m_AttackTimer += Time.deltaTime;
       
        if (m_AttackTimer >= 3)
        {
            m_PlayerManager.TakeDamage(30);
            m_AttackTimer = 0;
        }
    }
}
