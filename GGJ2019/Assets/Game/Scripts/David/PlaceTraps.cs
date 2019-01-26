using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTraps : MonoBehaviour
{
	[SerializeField] private Transform m_Camera;
	[SerializeField] private EditorManager m_EditorManager;
	private int m_CurrentTrap;
	private RaycastHit m_Hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (m_EditorManager.m_InEditorMode)
		{
			Debug.Log("hahahha");
			Vector3 fwd =  m_Camera.TransformDirection(Vector3.forward);
			if (Physics.Raycast(transform.position, fwd, out m_Hit, 50) && m_Hit.transform.CompareTag("TrapSpot"))
			{
				Debug.Log(m_Hit.transform.name);
				TrapSpot trapSpot = m_Hit.transform.GetComponent<TrapSpot>();
				trapSpot.m_Timer = 0.5f;
				trapSpot.m_BeingLookedAt = true;
			}
		}
    }
}
