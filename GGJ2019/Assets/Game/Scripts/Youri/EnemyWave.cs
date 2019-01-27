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

    [SerializeField] private List<GameObject> m_Enemys;

    private int m_Index;
    [SerializeField] private int m_CurrentWave;

    [SerializeField] private float m_Timer;
    [SerializeField] private float m_TimeUntillSpawn;
    [SerializeField] private float m_TimeBetweenWaves;

    private GameObject m_Spawnpoint;

    private void Start()
    {
        m_Enemys = new List<GameObject>();

        m_CurrentWave = 0;

        m_TimeUntillSpawn = 1f;

        m_Index = 0;
        m_Timer = 0;
        m_TimeBetweenWaves = 60;

        m_Spawnpoint = GameObject.FindGameObjectWithTag("Spawner");

    }

    private void Update()
    {
        m_Timer += Time.deltaTime;
        if(m_Timer >= 1f)
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

        m_EnemyCount.text = "" + m_Enemys.Count;
        m_WaveCount.text = "" + m_CurrentWave + "/7";
        m_TimerText.text = "" + Mathf.Round(m_TimeBetweenWaves -= Time.deltaTime).ToString();
    }

    private void SpawnWave()
    {        
        Vector3 spawnPoint = new Vector3(m_Spawnpoint.transform.position.x + Random.Range(-10, 10), m_Spawnpoint.transform.position.y, m_Spawnpoint.transform.position.z + Random.Range(-10, 10));
        Instantiate<GameObject>(m_Enemys[m_Index], spawnPoint, Quaternion.identity);
        m_Index += 1;
        Debug.Log("It sucseeded onii-chan");
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

    public void RemoveFromList(GameObject go)
    {
        m_Enemys.Remove(go);
    }

    private void SwitchBetweenWaves()
    {
        switch (m_CurrentWave)
        {
            case 1:
                if(m_Enemys.Count == 0 && m_Enemys.Count <= 8)
                    AddToWave(1, 7, 0);
                for (int i = 0; i < 8; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 2:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 10)
                    AddToWave(3, 6, 1);
                for (int i = 0; i < 10; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 3:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 13)
                    AddToWave(3, 8, 2);
                for (int i = 0; i < 13; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 4:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 15)
                    AddToWave(5, 6, 4);
                for (int i = 0; i < 15; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 5:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 18)
                    AddToWave(2, 15, 1);
                for (int i = 0; i < 18; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 6:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 16)
                    AddToWave(3, 5, 8);
                for (int i = 0; i < 16; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 7:
                if (m_Enemys.Count == 0 && m_Enemys.Count <= 30)
                    AddToWave(10, 10, 10);
                for (int i = 0; i < 30; i++)
                {
                    
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
        }
    }
}
