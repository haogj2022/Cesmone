using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWN, WAIT, COUNT};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;

    public float waveDelay = 3f;

    private int nextWave = 0;
    private float waveInterval;
    private float search = 1;

    public SpawnState state = SpawnState.COUNT;

    private void Start()
    {
        Debug.Log("Starting first wave...");

        waveInterval = waveDelay;
    }

    private void Update()
    {
        if (state == SpawnState.WAIT)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveInterval <= 0)
        {
            if (state != SpawnState.SPAWN)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveInterval -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNT;

        waveInterval = waveDelay;

        if (nextWave + 1 > waves.Length - 1)
        {
            Debug.Log("All waves completed!");
            state = SpawnState.WAIT;
        }
        else
        {
            Debug.Log("Starting next wave...");
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        search -= Time.deltaTime;

        if (search <= 0)
        {
            search = 1;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Wave started: " + _wave.name);

        state = SpawnState.SPAWN;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1 / _wave.rate);
        }

        state = SpawnState.WAIT;

        yield break;
    }

    void SpawnEnemy(Transform[] _enemy)
    {
        int randomEnemy = Random.Range(0, _enemy.Length);
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        Debug.Log("Enemy spawned: " + _enemy[randomEnemy]);

        Instantiate(_enemy[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }
}
