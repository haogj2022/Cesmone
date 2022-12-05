using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public TMP_Text waveName; //wave name text

    public float waveDelay = 5; //delay after completed wave

    int nextWave = 0; 
    float waveInterval; //pause between waves
    float search = 1; //search for alive enemies
    float winDelay = 2;

    SpawnState state = SpawnState.COUNT; //start count down

    bool canAnimate = true; //animation can play
   
    Image winScreen;

    public GameObject[] stats;

    JoystickController joystick;

    ReadInput timer; 

    void Start()
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

    void Update()
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

        //there is no more wave
        if (nextWave + 1 > waves.Length - 1)
        {
            if (canAnimate)
            {
                anim.SetTrigger("WaveComplete");
                anim.SetTrigger("AllClear");
                canAnimate = false;                               
            }
            
            StartCoroutine(PlayerWin());

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

    IEnumerator PlayerWin()
    {        
        timer = GameObject.Find("Hero Name").GetComponent<ReadInput>();
        timer.startTimer = false;
                
        yield return new WaitForSeconds(winDelay);
        
        joystick = GameObject.Find("Hero Selection").GetComponent<JoystickController>();
        joystick.isActive = false;
                
        winScreen = GameObject.Find("Win").GetComponent<Image>();
        winScreen.enabled = true;

        foreach (GameObject stat in stats)
        {
            yield return new WaitForSeconds(1);
            stat.SetActive(true);
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