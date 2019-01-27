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

        if (m_PlayerWithinAttackDistance == true)
        {
            Attack(m_Player.transform.position, true);
        }
        else if (m_DoorWithinAttackDistance == true)
        {
            Attack(m_Goal, false);
        }
    }

    public override void Attack(Vector3 pos, bool player)
    {
        m_EnemyState = EnemyState.Attacking;
        m_AttackTimer += Time.deltaTime;
       
        if (m_AttackTimer >= 3)
        {
            if (player)
            {
                m_PlayerManager.TakeDamage(30);
            }
            else if (!player)
            {
                m_DoorHealth.TakeDamage(15);
            }
            m_AttackTimer = 0;
        }
    }
}
