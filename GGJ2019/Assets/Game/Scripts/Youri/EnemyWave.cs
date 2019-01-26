using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField]
    private GameObject m_SmallEnemy, m_AverageEnemy, m_BigEnemy;

    private List<GameObject> m_Enemys;

    private int m_Index;
    private int m_CurrentWave;

    private float m_Timer;
    private float m_TimeUntillSpawn;
    private float m_TimeBetweenWaves;

    private GameObject m_Spawnpoint;

    private void Start()
    {
        m_CurrentWave = 1;

        m_Index = 0;
        m_Timer = 0;
        m_TimeBetweenWaves = 0;

        m_Spawnpoint = GameObject.FindGameObjectWithTag("Spawner");

    }

    private void Update()
    {
        switch (m_CurrentWave)
        {
            case 1:
                AddToWave(1, 8, 0);
                for(int i = 0; i < 8; i++)
                {
                    m_Timer += Time.deltaTime;
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }               
                break;
            case 2:
                AddToWave(3, 6, 1);
                for (int i = 0; i < 10; i++)
                {
                    m_Timer += Time.deltaTime;
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 3:
                AddToWave(3, 8, 2);
                for (int i = 0; i < 13; i++)
                {
                    m_Timer += Time.deltaTime;
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 4:
                AddToWave(5, 6, 4);
                for (int i = 0; i < 15; i++)
                {
                    m_Timer += Time.deltaTime;
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 5:
                AddToWave(2, 15, 1);
                for (int i = 0; i < 18; i++)
                {
                    m_Timer += Time.deltaTime;
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 6:
                AddToWave(3, 5, 8);
                for (int i = 0; i < 16; i++)
                {
                    m_Timer += Time.deltaTime;
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
            case 7:
                AddToWave(10, 10, 10);
                for (int i = 0; i < 30; i++)
                {
                    m_Timer += Time.deltaTime;
                    if (m_Timer >= m_TimeUntillSpawn)
                    {
                        SpawnWave();
                        m_Timer = 0;
                    }
                }
                break;
        }

        if(m_Enemys.Count == 0)
        {
            m_TimeBetweenWaves += Time.deltaTime;

            if(m_TimeBetweenWaves >= 60)
            {
                m_CurrentWave += 1;
            }
        }
    }

    private void SpawnWave()
    {        
        Vector3 spawnPoint = new Vector3(m_Spawnpoint.transform.position.x + Random.Range(-10, 10), m_Spawnpoint.transform.position.y, m_Spawnpoint.transform.position.z + Random.Range(-10, 10));
        Instantiate(m_Enemys[m_Index], spawnPoint, Quaternion.identity);
        m_Enemys.RemoveAt(m_Index);
        m_Index += 1;
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

        for(int i = 0; i < m_Enemys.Count; i++)
        {
            GameObject tempEnemy = m_Enemys[i];
            int randomIndex = Random.Range(i, m_Enemys.Count);
            m_Enemys[i] = m_Enemys[randomIndex];
            m_Enemys[randomIndex] = tempEnemy;
        }
    }
}
