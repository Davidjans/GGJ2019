using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
	[SerializeField] private float m_Damage;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<AverageEnemy>().TakeDamage(m_Damage);
		}
	}
}
