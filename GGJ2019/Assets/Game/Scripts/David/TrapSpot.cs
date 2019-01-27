using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpot : MonoBehaviour
{
	public float m_Timer;
	public bool m_BeingLookedAt;
	[SerializeField] private List<GameObject> m_EditorTraps;
	[SerializeField] private EditorManager m_EditorManager;
	[SerializeField] private List<int> m_TrapCosts;
	[SerializeField] private GameObject m_HighlightArea;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		m_HighlightArea.SetActive(false);
		m_Timer = -Time.deltaTime;
		for (int i = 0; i < m_EditorTraps.Count; i++)
		{
			m_EditorTraps[i].SetActive(false);
		}
		if (m_BeingLookedAt)
		{
			m_EditorTraps[m_EditorManager.CurrentTrap].SetActive(true);
			m_HighlightArea.SetActive(true);
		}
		if (m_Timer <= 0) {
			m_BeingLookedAt = false;
			
		}

    }

	public void PurchaseTrap()
	{
		if(m_EditorManager.m_PlayerManager.m_Money >= m_TrapCosts[m_EditorManager.CurrentTrap])
		{
			Instantiate<GameObject>(m_EditorManager.m_Traps[m_EditorManager.CurrentTrap], m_EditorTraps[m_EditorManager.CurrentTrap].transform.position, m_EditorTraps[m_EditorManager.CurrentTrap].transform.rotation, null);
			m_EditorManager.m_PlayerManager.m_Money = m_EditorManager.m_PlayerManager.m_Money - m_TrapCosts[m_EditorManager.CurrentTrap];
			Destroy(gameObject);
		}
	}
}
