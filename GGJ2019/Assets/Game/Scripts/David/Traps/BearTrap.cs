using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapState
{
	Ready,
	NotReady
}

public class BearTrap : MonoBehaviour
{
	
	[SerializeField] private float m_Damage;
	private bool m_CurrentlyActive = true;
	private float m_Timer = 6;
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
			m_Timer = m_Timer -Time.deltaTime;
		}
		if (m_Timer <= 0)
		{
			m_Timer = 6;
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
			AverageEnemy enemyHit = other.GetComponent<AverageEnemy>();
			enemyHit.TakeDamage(m_Damage);
			enemyHit.RootEnemy();
			m_Timer = 6;
			SetTrapState(TrapState.NotReady);
			m_CurrentlyActive = false;
			Debug.Log("Hallo2");
		}
	}
}
