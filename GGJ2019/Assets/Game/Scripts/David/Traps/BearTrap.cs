using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
	[SerializeField] private float m_Damage;
	private bool m_CurrentlyActive;
	private float m_Timer = 2;


	private void Update()
	{
		if (!m_CurrentlyActive)
		{
			m_Timer = -Time.deltaTime;
		}
		if (m_Timer <= 0)
		{
			m_Timer = 2;
			m_CurrentlyActive = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") && m_CurrentlyActive)
		{
			AverageEnemy enemyHit = other.GetComponent<AverageEnemy>();
			enemyHit.TakeDamage(m_Damage);
			enemyHit.RootEnemy();
			m_CurrentlyActive = false;
		}
	}
}
