using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EditorUI : MonoBehaviour
{
	[SerializeField] private EditorManager m_EditorManager;
	[SerializeField] private List<GameObject> m_Selected;
	[SerializeField] private GameObject m_EditorUI;
	[SerializeField] private TextMeshProUGUI m_MoneyText;
	[SerializeField] private PlayerManager m_PlayerManager;
	[SerializeField] private DoorHealth m_DoorHealth;
	[SerializeField] private Slider m_HealthSlider;
	[SerializeField] private Slider m_DoorHealthSlider;
	// Start is called before the first frame update
	void Start()
	{
		m_HealthSlider.maxValue = m_PlayerManager.m_MaxHealth;
		m_DoorHealthSlider.maxValue = m_DoorHealth.m_MaxHealth;
	}

	// Update is called once per frame
	void Update()
	{
		m_MoneyText.text = m_PlayerManager.m_Money.ToString();
		m_HealthSlider.value = m_PlayerManager.m_Health;
		m_DoorHealthSlider.value = m_DoorHealth.m_Health;
		if (m_EditorManager.m_InEditorMode == true)
		{
			m_EditorUI.SetActive(true);
		}
		else
		{
			m_EditorUI.SetActive(false);
		}
		ResetSeleceted();
		if (m_EditorManager.CurrentTrap == 0)
		{
			m_Selected[0].SetActive(true);
		}
		else if (m_EditorManager.CurrentTrap == 1)
		{
			m_Selected[1].SetActive(true);
		}
		else if (m_EditorManager.CurrentTrap == 2)
		{
			m_Selected[2].SetActive(true);
		}
		else if (m_EditorManager.CurrentTrap == 3)
		{
			m_Selected[3].SetActive(true);
		}
		else if (m_EditorManager.CurrentTrap == 4)
		{
			m_Selected[4].SetActive(true);
		}
	}

	private void ResetSeleceted (){
		for (int i = 0; i < m_Selected.Count; i++)
		{
			m_Selected[i].SetActive(false);
		}
	}
}
