using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTraps : MonoBehaviour
{
	[SerializeField] private Transform m_Camera;
	[SerializeField] private EditorManager m_EditorManager;
	private int m_CurrentTrap;
	private RaycastHit m_Hit;
	private int m_Rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (m_EditorManager.m_InEditorMode)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				m_Rotation = m_Rotation - 90;
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				m_Rotation = m_Rotation + 90;
			}
			if(m_Rotation > 360)
			{
				m_Rotation = 90;
			}
			if(m_Rotation < 0)
			{
				m_Rotation = 270;
			}
			Debug.Log("hahahha");
			Vector3 fwd =  m_Camera.TransformDirection(Vector3.forward);
			if (Physics.Raycast(transform.position, fwd, out m_Hit, 50) && m_Hit.transform.CompareTag("TrapSpot"))
			{
				m_Hit.transform.eulerAngles = new Vector3(0, m_Rotation, 0);
				TrapSpot trapSpot = m_Hit.transform.GetComponent<TrapSpot>();
				trapSpot.m_Timer = 0.5f;
				trapSpot.m_BeingLookedAt = true;
				if (Input.GetMouseButtonDown(0))
				{
					trapSpot.PurchaseTrap();
				}
			}
		}
    }
}
