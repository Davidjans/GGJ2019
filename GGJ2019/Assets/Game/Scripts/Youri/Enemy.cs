using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle = 0,
    Walking,
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
    private float m_IdleTimer;

    protected bool m_WithinAttackDistance;

    [SerializeField] protected float m_Health;

    protected bool m_IsRooted;

    private EnemyWave m_EW;

    protected EnemyState m_EnemyState;

    protected Animator m_Animator;

    private void Start()
    {
        m_EnemyState = EnemyState.Idle;
        
        m_Goal = GameObject.FindGameObjectWithTag("Goal").transform.position;
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_EW = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemyWave>();
        m_Animator = GetComponent<Animator>();

        m_NMA = GetComponent<NavMeshAgent>();

        m_AttackTimer = 0;
        m_RootTimer = 0;
        m_IdleTimer = 0;
        m_PlayerManager = GetComponent<PlayerManager>();

        m_NMA.speed = m_Speed;
    }

    public virtual void Update()
    {
        if(m_EnemyState != EnemyState.Idle)
        {
            m_IdleTimer += Time.deltaTime;
            if(m_IdleTimer >= 3f)
            {
                m_EnemyState = EnemyState.Idle;
                m_IdleTimer = 0;
            }
        }

        m_Animator.SetInteger("EnemyState", (int)m_EnemyState);
    }

    public virtual void Attack()
    {

    }

    public void Move()
    {
        m_EnemyState = EnemyState.Walking;

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
			if(m_EW != null)
			{
				m_EW.RemoveFromList(gameObject);
			}

            m_EW.RemoveFromList(gameObject);
            m_EnemyState = EnemyState.Dying;
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
