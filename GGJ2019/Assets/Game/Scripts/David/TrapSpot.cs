using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpot : MonoBehaviour
{
	public float m_Timer;
	public bool m_BeingLookedAt;
	[SerializeField] private List<GameObject> m_EditorTraps;
	[SerializeField] private EditorManager m_EditorManager;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (m_BeingLookedAt)
		{
			for (int i = 0; i < m_EditorTraps.Count; i++)
			{
				m_EditorTraps[i].SetActive(false);
			}
			m_EditorTraps[m_EditorManager.CurrentTrap].SetActive(true);
			m_Timer = -Time.deltaTime;
		}
		if (m_Timer <= 0) {
			m_BeingLookedAt = false;
		}
    }
}
