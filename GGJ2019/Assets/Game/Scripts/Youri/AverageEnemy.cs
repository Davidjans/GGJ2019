using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class AverageEnemy : Enemy
{
    [SerializeField]
    private GameObject m_Spit;

    public override void Update()
    {
        base.Update();

        if(m_IsRooted == false && m_IsStunned == false)
        {
            Move();
        }

        if(m_PlayerWithinAttackDistance == true)
        {
            Attack(m_Player.transform.position, true);
        }
        else if (m_DoorWithinAttackDistance == true)
        {
            Attack(m_Goal, false);
        }
    }

    public override void Attack(Vector3 position, bool player)
    {
        m_EnemyState = EnemyState.Attacking;
        m_AttackTimer += Time.deltaTime;
        if (m_AttackTimer >= 1)
        {
            if (player)
            {
                GameObject go = Instantiate(m_Spit, transform.position, Quaternion.identity);
                Spit spit = go.GetComponent<Spit>();
                spit.SetDirection(position - transform.position);
            }
            else if (!player)
            {
                GameObject go = Instantiate(m_Spit, transform.position, Quaternion.identity);
                Spit spit = go.GetComponent<Spit>();
                spit.SetDirection(position - transform.position);
            }
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
