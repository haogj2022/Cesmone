using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Created by: Nguyen Anh Hao
//Date created: 18/11/2022
//Object(s) holding this script: All game objects with 'Spawner' tag
//Summary: Spawn random enemies each wave

[System.Serializable]
public class Wave
{
    public string name; 
    public Transform[] enemy; 
    public int count; 
    public float rate; 
}

//the current states of the wave spawner
public enum SpawnState 
{ 
    SPAWN, 
    WAIT, 
    COUNT
};

public class WaveSpawner : MonoBehaviour, IDataPersistence
{        
    public Wave[] waves;
    public Transform[] spawnPoints; 
    
    public TMP_Text waveName;
    public GameObject clearText;
    public Button nextLevel;
    public GameObject[] trapButton;  

    public bool canSpawn = true;

    float waveDelay = 5;       
    float waveInterval;
    float search = 1; 
    float winDelay = 2;
    float loseDelay = 5;

    int nextWave = 0; 
    bool canAnimate = true;
    bool isClear = false;

    SpawnState state = SpawnState.COUNT; 
    
    Animator anim; 
    Image winScreen;
    Image loseScreen;
    PlayerController playerController; 
    LevelStats levelStat;
    CastleHealthText castle;
    SpawnerManager level;

    [SerializeField] string id;

    [ContextMenu("Generate guid for id")]

    void GeneratedGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(SaveData data)
    {
        data.isClear.TryGetValue(id, out isClear);

        if (isClear)
        {
            //enable clear text
            clearText.SetActive(true);

            //enable next level
            nextLevel.interactable = true;
        }
    }

    public void SaveData(ref SaveData data)
    {
        if (data.isClear.ContainsKey(id))
        {
            data.isClear.Remove(id);
        }

        data.isClear.Add(id, isClear);
    }

    //called in SpawnerManager script to start the chosen level
    public void StartLevel()
    {
        //find wave animation game object in hierarchy
        anim = GameObject.Find("Wave Animation").GetComponent<Animator>();

        //find castle game object in hierarchy
        castle = GameObject.Find("Castle").GetComponent<CastleHealthText>();

        //find spawner manager object in hierarchy
        level = GameObject.Find("Spawner Manager").GetComponent<SpawnerManager>();
        
        //count down the first wave
        waveInterval = waveDelay;
        state = SpawnState.COUNT;
        
        //start first wave
        nextWave = 0;
        canSpawn = true;
        canAnimate = true;

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

        //when castle is destroyed
        if (castle.currentHealth <= 0)
        {   
            //stop spawning enemies
            canSpawn = false;

            //when wave animations can play
            if (canAnimate)
            {   
                //player loses the level
                StartCoroutine(PlayerLose());

                //stop playing wave animations
                canAnimate = false;
            }

            //wait for player to go back to main menu
            state = SpawnState.WAIT;
        }
        else //when castle is not destroyed
        {
            //there is no more wave
            if (nextWave + 1 > waves.Length - 1)
            {
                //when wave animations can play
                if (canAnimate)
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

                //wait for player to go back to main menu
                state = SpawnState.WAIT;
            }
            else //there is still a wave
            {
                //continue to the next wave
                nextWave++;

                //when wave animations can play
                if (canAnimate)
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
            }
        }       
    }

    //called by WaveCompleted() when player completed all the waves
    IEnumerator PlayerWin()
    {   
        //all wave is clear
        isClear = true;
        
        //when player clear the level
        if (isClear)
        {
            //enable clear text
            clearText.SetActive(true);

            //enable next level
            nextLevel.interactable = true;
        }

        //level is complete
        level.LevelComplete();
        
        //stop the timer
        levelStat = GameObject.Find("Win & Lose Screen").GetComponent<LevelStats>();
        levelStat.startTimer = false;
                
        //wait for a few seconds
        yield return new WaitForSeconds(winDelay);
        
        //disable player controller
        playerController = GameObject.Find("Player Character").GetComponent<PlayerController>();
        playerController.isActive = false;

        foreach(GameObject button in trapButton)
        {
            button.SetActive(false);
        }

        //enable the victory screen
        winScreen = GameObject.Find("Win").GetComponent<Image>();
        winScreen.enabled = true;

        //show the stats one by one
        foreach (GameObject stat in levelStat.stats)
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
        levelStat = GameObject.Find("Win & Lose Screen").GetComponent<LevelStats>();
        levelStat.startTimer = false;

        //wait for a few seconds
        yield return new WaitForSeconds(loseDelay);

        //disable player controller
        playerController = GameObject.Find("Player Character").GetComponent<PlayerController>();
        playerController.isActive = false;

        foreach (GameObject button in trapButton)
        {
            button.SetActive(false);
        }

        //enable the defeat screen
        loseScreen = GameObject.Find("Lose").GetComponent<Image>();
        loseScreen.enabled = true;

        //show the stats one by one
        foreach (GameObject stat in levelStat.stats)
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