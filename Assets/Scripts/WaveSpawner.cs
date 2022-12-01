using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 18/11/2022
//Summary: Spawn random enemies each wave

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWN, WAIT, COUNT}; //states of the wave

    //make the class editable in Inspector
    [System.Serializable]
    public class Wave
    {
        public string name; //name of the wave
        public Transform[] enemy; //random enemies
        public int count; //number of enemies in the wave
        public float rate; //how often the enemies spawn
    }

    public Wave[] waves; //number of waves
    public Transform[] spawnPoints; //enemies spawn positions
    public Animator anim;
    public TMP_Text waveName;

    public float waveDelay = 5; //delay after completed wave

    private int nextWave = 0; 
    private float waveInterval; //pause between waves
    private float search = 1; //search for alive enemies

    public SpawnState state = SpawnState.COUNT; //start count down

    private bool canAnimate = true;

    private void Start()
    {        
        waveInterval = waveDelay; //delay for a few seconds

        if (canAnimate)
        {
            waveName.text = waves[nextWave].name;
            anim.SetTrigger("WaveStart");
            anim.SetTrigger("NextWave");
            canAnimate = false;
        }
    }

    private void Update()
    {
        //wait for player to kill all enemies
        if (state == SpawnState.WAIT)
        {
            //no enemy is alive
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else //there is still an enemy
            {
                return; //let player kill it
            }
        }

        //pause between waves is done
        if (waveInterval <= 0)
        {
            //enemies are not spawning
            if (state != SpawnState.SPAWN)
            {
                StartCoroutine(SpawnWave(waves[nextWave])); //start the next wave               
            }
        }
        else //enemies already spawned
        {
            waveInterval -= Time.deltaTime; //start pause between waves
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNT; //count down next wave

        waveInterval = waveDelay; //delay for a few seconds

        //no more next wave
        if (nextWave + 1 > waves.Length - 1)
        {
            if (canAnimate)
            {
                anim.SetTrigger("WaveComplete");
                anim.SetTrigger("AllClear");
                canAnimate = false;
            }

            state = SpawnState.WAIT;
        }
        else //there is still a wave
        {           
            nextWave++;

            if (canAnimate)
            {
                waveName.text = waves[nextWave].name;
                anim.SetTrigger("WaveComplete");
                anim.SetTrigger("NextWave");
                canAnimate = false;
            }
        }
    }

    bool EnemyIsAlive()
    {
        search -= Time.deltaTime; //start search for alive enemy

        //search for it every second
        if (search <= 0)
        {
            search = 1;

            //no alive enemy left
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        canAnimate = true;

        state = SpawnState.SPAWN; //start spawn enemies        

        //spawn correct number of enemies
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
        int randomEnemy = Random.Range(0, _enemy.Length); //random enemies
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length); //random spawn position

        Instantiate(_enemy[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity); //spawn a random enemy at a random spawn position
    }
}
