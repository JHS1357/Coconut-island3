using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    private float countdown = 2.0f;         // ���̺� �ð� ����
    public float timeBetweenWaves = 5.0f;   // ���̺� �߻� �ð�����
    public float spawnTime = .5f;           // �� ���� �ð�����

    private int waveIndex = 0;  // ���̺� ������ �� �� 
  
    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0.0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}