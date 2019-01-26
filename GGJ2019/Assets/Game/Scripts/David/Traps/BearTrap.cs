using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
	[SerializeField] private float m_Damage;
	private bool m_CurrentlyActive;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") )
		{
			AverageEnemy enemyHit = other.GetComponent<AverageEnemy>();
			enemyHit.TakeDamage(m_Damage);
			//other.GetComponent<AverageEnemy>()
		}
	}
}
