using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 18/11/2022
//Object(s) holding this script: Level 1
//Summary: Spawn random enemies each wave

public class WaveSpawner : MonoBehaviour
{
    //the current states of the wave spawner
    public enum SpawnState { SPAWN, WAIT, COUNT}; 

    //make the class editable in Inspector
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
    public Animator anim; 
    public TMP_Text waveName; 
    public GameObject[] stats;

    public float waveDelay = 5; 
    public bool canAnimate = true;
    public bool canSpawn = true;
    public int nextWave = 0; 
    
    float waveInterval;
    float search = 1; 
    float winDelay = 2;
    float loseDelay = 5;
    
    SpawnState state = SpawnState.COUNT; 
      
    Image winScreen;
    Image loseScreen;
    JoystickController joystick; 
    PlayerStats timer;
    CastleHealth castle;
    LevelSelection level;

    //called by LevelSelection.Level1() to start level 1
    public void StartLevel()
    {
        //find castle game object in hierarchy
        castle = GameObject.Find("Castle").GetComponent<CastleHealth>();

        //find wave spawner object in hierarchy
        level = GameObject.Find("WaveSpawner").GetComponent<LevelSelection>();
        
        nextWave = 0;
        
        canAnimate = true;

        //start count down for the first wave
        waveInterval = waveDelay;

        state = SpawnState.COUNT;

        //when wave animations can play
        if (canAnimate)
        {
            //play wave start animation
            anim.SetTrigger("WaveStart");
            
            //show the wave name on screen
            waveName.text = waves[nextWave].name;
            
            //play next wave animation
            anim.SetTrigger("NextWave");

            //stop playing wave animations
            canAnimate = false;
        }
    }

    void Update()
    {
        SpawnEvent();    
    }

    //called by Update() to manage spawn event
    void SpawnEvent()
    {
        //wait for player to kill all enemies
        if (state == SpawnState.WAIT)
        {
            //no enemy is alive
            if (!EnemyIsAlive())
            {
                //wave is completed
                WaveCompleted();
            }
            else //there is still an enemy
            {
                //when castle is destroyed
                if (castle.currentHealth <= 0)
                {
                    //end the wave so enemies do not spawn
                    WaveCompleted();
                }
                else //when castle is not destroyed
                {
                    //let player kill the enemy
                    return;
                }
            }
        }

        //pause between waves is done
        if (waveInterval <= 0)
        {
            //enemies are not spawning
            if (state != SpawnState.SPAWN)
            {
                //start the next wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else //enemies already spawned
        {
            //wait for the wave to be completed
            waveInterval -= Time.deltaTime;
        }
    }
   
    //called by Update() when a wave is completed
    void WaveCompleted()
    {        
        //count down for the next wave
        waveInterval = waveDelay;
        
        //wait for the count down
        state = SpawnState.COUNT;

        //there is no more wave
        if (nextWave + 1 > waves.Length - 1)
        {
            //when wave animations can play
            if (canAnimate)
            {
                //castle is not destroyed
                if (castle.currentHealth > 0)
                {
                    //play wave complete animation
                    anim.SetTrigger("WaveComplete");

                    //play all clear animation
                    anim.SetTrigger("AllClear");

                    //player wins the level
                    StartCoroutine(PlayerWin());

                    //stop playing wave animations
                    canAnimate = false;
                }
            }
            
            state = SpawnState.WAIT;                      
        }
        else //there is still a wave
        {
            //continue to the next wave
            nextWave++; 

            //when wave animations can play
            if (canAnimate)
            {                 
                //castle is not destroyed
                if (castle.currentHealth > 0)
                {
                    //play wave start animation
                    anim.SetTrigger("WaveComplete");

                    //show the wave name on screen
                    waveName.text = waves[nextWave].name;

                    //play next wave animation
                    anim.SetTrigger("NextWave");

                    //stop playing wave animations
                    canAnimate = false;
                }
                else //castle is destroyed
                {
                    //player loses the level
                    StartCoroutine(PlayerLose());
                }               
            }                        
        }
    }

    //called by WaveCompleted() when player completed all the waves
    IEnumerator PlayerWin()
    {
        //level is complete
        level.LevelComplete();

        //stop the timer
        timer = GameObject.Find("Hero Name").GetComponent<PlayerStats>();
        timer.startTimer = false;
                
        //wait for a few seconds
        yield return new WaitForSeconds(winDelay);
        
        //hide the joystick on screen
        joystick = GameObject.Find("Hero Selection").GetComponent<JoystickController>();
        joystick.isActive = false;
                
        //enable the victory screen
        winScreen = GameObject.Find("Win").GetComponent<Image>();
        winScreen.enabled = true;

        //show the stats one by one
        foreach (GameObject stat in stats)
        {
            yield return new WaitForSeconds(1);
            stat.SetActive(true);
        }
    }

    //called by WaveComplete() when player fails to defend the castle
    IEnumerator PlayerLose()
    {
        //level is complete
        level.LevelComplete();

        //stop the timer
        timer = GameObject.Find("Hero Name").GetComponent<PlayerStats>();
        timer.startTimer = false;

        //wait for a few seconds
        yield return new WaitForSeconds(loseDelay);

        //hide the joystick on screen
        joystick = GameObject.Find("Hero Selection").GetComponent<JoystickController>();
        joystick.isActive = false;

        //enable the defeat screen
        loseScreen = GameObject.Find("Lose").GetComponent<Image>();
        loseScreen.enabled = true;

        //show the stats one by one
        foreach (GameObject stat in stats)
        {
            yield return new WaitForSeconds(1);
            stat.SetActive(true);
        }
    }

    //called by SpawnEvent() when checking for alive enemies
    bool EnemyIsAlive()
    {
        //search for alive enemies
        search -= Time.deltaTime; 
        
        //for every second
        if (search <= 0)
        {
            search = 1; //search again

            //cannot find any game object with tag "Enemy"
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {   
                //no enemy alive
                return false; 
            }
        }
        
        //there is still an enemy
        return true; 
    }

    //called by SpawnEvent() when starting a new wave
    IEnumerator SpawnWave(Wave _wave)
    {
        //enable wave animations
        canAnimate = true;

        //start spawning enemies
        state = SpawnState.SPAWN;

        //spawn correct number of enemies
        for (int i = 0; i < _wave.count; i++)
        {
            //enemy can spawn
            if (canSpawn)
            {
                //spawn the enemies
                SpawnEnemy(_wave.enemy);
            }
            else //enemy cannot spawn
            {
                //break out of the loop
                break;
            }

            //wait for a few seconds
            yield return new WaitForSeconds(1 / _wave.rate);
        }

        //wait for the wave to be completed
        state = SpawnState.WAIT;

        //break out of the function
        yield break;            
    }

    //called by SpawnWave() when spawning an enemy
    void SpawnEnemy(Transform[] _enemy)
    {
        //pick a random enemy from the enemy array
        int randomEnemy = Random.Range(0, _enemy.Length); 

        //choose a random spawn position from the spawn point array
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        //spawn the picked enemy at chosen position
        Instantiate(_enemy[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity); 
    }
}