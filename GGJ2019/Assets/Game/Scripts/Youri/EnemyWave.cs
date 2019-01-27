using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyWave : MonoBehaviour
{
    [SerializeField]
    private GameObject m_SmallEnemy, m_AverageEnemy, m_BigEnemy;

    [SerializeField]
    private TextMeshProUGUI m_EnemyCount, m_WaveCount, m_TimerText;

    private List<GameObject> m_Enemys;
    public List<GameObject> m_CurrentEnemy;

    public int m_Index;
    [SerializeField] private int m_CurrentWave;

    [SerializeField] private float m_Timer;
    [SerializeField] private float m_TimeUntillSpawn;
    [SerializeField] private float m_TimeBetweenWaves;

    [SerializeField] private List<GameObject> m_Spawnpoint;

    private void Start()
    {
        m_Enemys = new List<GameObject>();
        m_CurrentEnemy = new List<GameObject>();

        m_CurrentWave = 0;

        m_TimeUntillSpawn = 1f;

        m_Index = 0;
        m_Timer = 0;
        m_TimeBetweenWaves = 60;

    }

    private void Update()
    {
        m_Timer += Time.deltaTime;

        for (int i = 0; i < m_CurrentEnemy.Count; i++)
        {
            if(m_CurrentEnemy[i] == null)
            {
                m_CurrentEnemy.RemoveAt(i);

            }
        }

        if (m_Timer >= 1f)
        {
            SwitchBetweenWaves();
        }

        if (m_Enemys.Count == 0 && m_CurrentWave < 7)
        {
            m_TimeBetweenWaves -= Time.deltaTime;

            if (m_TimeBetweenWaves <= 0)
            {
                m_CurrentWave += 1;
                m_TimeBetweenWaves = 60;

            }
        }

        m_EnemyCount.text = "" + m_CurrentEnemy.Count;
        m_WaveCount.text = "" + m_CurrentWave + "/7";
        m_TimerText.text = "" + Mathf.Round(m_TimeBetweenWaves -= Time.deltaTime).ToString();

        Debug.Log(m_CurrentEnemy.Count);
    }

    private void SpawnWave(int countOfEnemies)
    {        
        for(int i = 0; i < countOfEnemies; i++)
        {
			int random = Random.Range(0, m_Spawnpoint.Count);
            Vector3 spawnPoint = new Vector3(m_Spawnpoint[random].transform.position.x + Random.Range(-10, 10), m_Spawnpoint[random].transform.position.y, m_Spawnpoint[random].transform.position.z + Random.Range(-10, 10));
            m_CurrentEnemy.Add(Instantiate<GameObject>(m_Enemys[m_Index], spawnPoint, Quaternion.identity));
            m_Index += 1;

            Debug.Log("It sucseeded onii-chan");
        }      
    }

    public void AddToWave(int s, int a, int b)
    {

        for(int i  = 0; i < s; i++)
        {
            m_Enemys.Add(m_SmallEnemy);
        }
        for (int i = 0; i < a; i++)
        {
            m_Enemys.Add(m_AverageEnemy);
        }
        for (int i = 0; i < b; i++)
        {
            m_Enemys.Add(m_BigEnemy);
        }

        for (int i = 0; i < m_Enemys.Count; i++)
        {
            GameObject tempEnemy = m_Enemys[i];
            int randomIndex = Random.Range(i, m_Enemys.Count);
            m_Enemys[i] = m_Enemys[randomIndex];
            m_Enemys[randomIndex] = tempEnemy;
        }
    }

    public void UpdateEnemyCountText()
    {
        m_EnemyCount.text = "" + m_Enemys.Count;
    }

    //public void RemoveFromList(GameObject go)
    //{
    //    for (int i = 0; i < m_CurrentEnemy.Count; i++)
    //    {
    //        if (m_CurrentEnemy[i] == null)
    //        {
    //            m_CurrentEnemy.RemoveAt(i);
    //        }
    //    }
    //}

    private void SwitchBetweenWaves()
    {
        switch (m_CurrentWave)
        {
            case 1:
                if(m_Enemys.Count == 0 && m_Enemys.Count <= 8)
                    AddToWave(1, 4, 0);
                for (int i = 0; i < 5; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave(5);
                        m_Timer = 0;
                    }
                }
                break;
            case 2:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 10)
                    AddToWave(2, 4, 1);
                for (int i = 0; i < 7; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave(7);
                        m_Timer = 0;
                    }
                }
                break;
            case 3:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 13)
                    AddToWave(1, 5, 2);
                for (int i = 0; i < 8; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave(8);
                        m_Timer = 0;
                    }
                }
                break;
            case 4:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 15)
                    AddToWave(3, 5, 2);
                for (int i = 0; i < 10; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave(10);
                        m_Timer = 0;
                    }
                }
                break;
            case 5:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 18)
                    AddToWave(0, 8, 1);
                for (int i = 0; i < 18; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave(9);
                        m_Timer = 0;
                    }
                }
                break;
            case 6:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 16)
                    AddToWave(2, 3, 4);
                for (int i = 0; i < 16; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave(9);
                        m_Timer = 0;
                    }
                }
                break;
            case 7:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 30)
                    AddToWave(4, 4, 4);
                for (int i = 0; i < 12; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave(12);
                        m_Timer = 0;
                    }
                }
                break;
        }
    }
}
