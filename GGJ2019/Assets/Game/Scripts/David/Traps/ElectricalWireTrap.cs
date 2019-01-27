using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalWireTrap : MonoBehaviour
{
	[SerializeField] private float m_Damage;
	[SerializeField] private GameObject m_Spark;
	private bool m_CurrentlyActive = true;
	private float m_Timer = 8;

	private void Update()
	{
		if (!m_CurrentlyActive)
		{
			m_Timer = m_Timer - Time.deltaTime;
		}
		if (m_Timer <= 0)
		{
			m_Timer = 8;
			m_CurrentlyActive = true;
			m_Spark.SetActive(true);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") && m_CurrentlyActive)
		{
			Enemy enemyHit = other.GetComponent<Enemy>();
			enemyHit.TakeDamage(m_Damage);
			enemyHit.StunEnemy();
			m_Timer = 8;
			m_CurrentlyActive = false;
			m_Spark.SetActive(false);
		}
	}
}
