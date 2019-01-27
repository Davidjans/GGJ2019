using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveTrap : MonoBehaviour
{
	[SerializeField] private float m_Damage;
	private bool m_CurrentlyActive = true;
	private float m_Timer = 5;
	private TrapState m_TrapState;
	private Animator m_Animator;

	public void SetTrapState(TrapState trapState)
	{
		m_TrapState = trapState;
	}

	private void Start()
	{
		m_Animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (!m_CurrentlyActive)
		{
			m_Timer = m_Timer - Time.deltaTime;
		}
		if (m_Timer <= 0)
		{
			m_Timer = 5;
			m_CurrentlyActive = true;
			SetTrapState(TrapState.Ready);
		}
		m_Animator.SetInteger("State", (int)m_TrapState);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") && m_CurrentlyActive)
		{
			Debug.Log("hallo");
			Enemy enemyHit = other.GetComponent<Enemy>();
			enemyHit.TakeDamage(m_Damage);
			enemyHit.ApplyKnockback(transform.position);
			m_Timer = 5;
			SetTrapState(TrapState.NotReady);
			m_CurrentlyActive = false;
			Debug.Log("Hallo2");
		}
	}
}
