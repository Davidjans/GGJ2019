using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTraps : MonoBehaviour
{
	[SerializeField] private Transform m_Camera;
	private bool m_CurrentlyEditing;
	private int m_CurrentTrap;
	private RaycastHit m_Hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (m_CurrentlyEditing)
		{
			Vector3 fwd =  m_Camera.TransformDirection(Vector3.forward);
			if (Physics.Raycast(transform.position, fwd, out m_Hit, 10) && m_Hit.transform.CompareTag("TrapSpot"))
			{
				TrapSpot trapSpot = m_Hit.transform.GetComponent<TrapSpot>();
				trapSpot.m_Timer = 0.5f;
				trapSpot.m_BeingLookedAt = true;
			}
		}
    }
}
