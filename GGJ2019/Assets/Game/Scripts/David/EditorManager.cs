using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditorManager : MonoBehaviour
{
	public int CurrentTrap;
	public bool m_InEditorMode;
	[SerializeField] private List<GameObject> m_Traps;
	[SerializeField] private TextMeshProUGUI m_EditorModeText;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Q)){
			m_InEditorMode = !m_InEditorMode;
		}

		if (m_InEditorMode)
		{
			m_EditorModeText.text = "In EditorMode";
			TrapSelect();
		}
		else if (!m_InEditorMode)
		{
			m_EditorModeText.text = "";
		}
    }

	private void TrapSelect()
	{
		if (Input.GetKeyDown(KeyCode.F1))
		{
			CurrentTrap = 0;
		}
		else if (Input.GetKeyDown(KeyCode.F2))
		{
			CurrentTrap = 1;
		}
		else if (Input.GetKeyDown(KeyCode.F3))
		{
			CurrentTrap = 2;
		}
		else if (Input.GetKeyDown(KeyCode.F4))
		{
			CurrentTrap = 3;
		}
		else if (Input.GetKeyDown(KeyCode.F5))
		{
			CurrentTrap = 4;
		}
	}


}
