using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [Header("Object References")]
    public GameObject enemySpawner;

    public BPM BPM;

    public List<GameObject> enemies;

    [Header("Waves Lists")]
    public List<GameObject> waveOne;
    public List<GameObject> waveTwo;

    [Header ("Wave Triggers")]
    [SerializeField]
    private float spawnTimer;
    private bool waveActive = false;

    public int waveNumber;

    private void Start()
    {
        spawnTimer = BPM.timeForBeat;
    }

    void Update()
    {
        spawnTimer = BPM.timeForBeat;
        if (!waveActive)
        {
            waveActive = true;
            StartWave();
        }
        
        if(enemies.Count == 0)
        {
            waveActive = false;
        }
    }

    void StartWave()
    {        
        //Case system for waves
        switch (waveNumber)
        {            
            //first wave
            case 0:
                StartCoroutine(SpawnEnemy(waveOne));
                break;
            //Second wave
            case 1:
                StartCoroutine(SpawnEnemy(waveTwo));
                break;
        }

        //Increment Wave
        ++waveNumber;        
    }

    IEnumerator SpawnEnemy(List<GameObject> currentWave)
    {
        GameObject temp;

        foreach (GameObject creep in currentWave)
        {
            temp = Instantiate(creep, enemySpawner.transform.position, Quaternion.Euler(0, 0, 0), enemySpawner.transform);
            enemies.Add(temp);
            yield return new WaitForSeconds(spawnTimer);
        }
        
    }
}
