using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState{
    Idle,
    Attacking,
    Dying
};

public class AverageEnemy : MonoBehaviour, IEnemy
{
    [SerializeField]
    private GameObject m_Spit;

    [SerializeField]
    private float m_Speed;

    private Vector3 m_Goal;

    private GameObject m_Player;

    private NavMeshAgent m_NMA;
    private PlayerController m_PlayerController;

    private float m_AttackTimer;

    private bool m_WithinAttackDistance;

    private float m_Health; 

    private void Start()
    {
        m_Goal = GameObject.FindGameObjectWithTag("Goal").transform.position;
        m_Player = GameObject.FindGameObjectWithTag("Player");

        m_NMA = GetComponent<NavMeshAgent>();

        m_AttackTimer = 0;
        m_PlayerController = GetComponent<PlayerController>();

        m_NMA.speed = m_Speed;
    }

    private void Update()
    {
        Move();

        if(m_WithinAttackDistance == true)
        {
            Attack();
        }
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

    public void Attack()
    {
        m_AttackTimer += Time.deltaTime;

        if(m_AttackTimer >= 2)
        {
            GameObject go = Instantiate(m_Spit, transform.position, Quaternion.identity);
            Spit spit = go.GetComponent<Spit>();
            spit.SetDirection(m_Player.transform.position - transform.position);
            m_AttackTimer = 0;
        }
    }

    public void TakeDamage(float value)
    {
        m_Health -= value;
    }

    public void Die()
    {

        Destroy(gameObject);
    }

    private bool PlayerInVision()
    {
        RaycastHit hit;

        Vector3 rayDirection = m_Player.transform.position - transform.position;

        if(Vector3.Angle(rayDirection, transform.forward) >= -90 && Vector3.Angle(rayDirection, transform.forward) <= 90)
        {
            if(Physics.Raycast(transform.position, rayDirection, out hit, 2f))
            {
                if(Vector3.Distance(transform.position, hit.transform.position) < 2f && hit.transform.tag == "Player")
                {
                    m_WithinAttackDistance = true;
                }
                else
                {
                    m_WithinAttackDistance = false;
                }
                if(hit.transform.tag == "Player")
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        return false;
    }
}

public interface IEnemy
{
    void Move();
    void Attack();
    void Die();
}
