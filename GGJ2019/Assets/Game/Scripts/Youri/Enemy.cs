using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    walking,
    Attacking,
    Dying
};
public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float m_Speed, m_RootTime;

    protected Vector3 m_Goal;

    protected GameObject m_Player;

    protected NavMeshAgent m_NMA;
    protected PlayerManager m_PlayerManager;

    protected float m_AttackTimer;
    protected float m_RootTimer;

    protected bool m_WithinAttackDistance;

    [SerializeField] protected float m_Health;

    protected bool m_IsRooted;

    private void Start()
    {
        m_Goal = GameObject.FindGameObjectWithTag("Goal").transform.position;
        m_Player = GameObject.FindGameObjectWithTag("Player");

        m_NMA = GetComponent<NavMeshAgent>();

        m_AttackTimer = 0;
        m_RootTimer = 0;
        m_PlayerManager = GetComponent<PlayerManager>();

        m_NMA.speed = m_Speed;
    }

    public virtual void Attack()
    {

    }

    public void Move()
    {
        if (PlayerInVision())
        {
            m_NMA.destination = m_Player.transform.position;
            transform.LookAt(m_Player.transform.position);
        }
        else
        {
            m_NMA.destination = m_Goal;
            transform.LookAt(m_Goal);
        }
    }

    public void TakeDamage(float value)
    {
        m_Health -= value;
		if(m_Health <= 0)
		{
			Destroy(gameObject);
		}
    }

    private bool PlayerInVision()
    {
        RaycastHit hit;

        Vector3 rayDirection = m_Player.transform.position - transform.position;
        
        if (Vector3.Angle(rayDirection, transform.forward) >= -180 && Vector3.Angle(rayDirection, transform.forward) <= 180)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, 10f))
            {
                Debug.DrawRay(transform.position, rayDirection, Color.red);
                if (Vector3.Distance(transform.position, hit.transform.position) < 10f && hit.transform.tag == "Player")
                {
                    Debug.DrawRay(transform.position, rayDirection, Color.green);
                    m_WithinAttackDistance = true;
                }
                else
                {
                    m_WithinAttackDistance = false;
                }
                if (hit.transform.tag == "Player")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }

    public void RootEnemy()
    {
        m_IsRooted = true;
    }
}
