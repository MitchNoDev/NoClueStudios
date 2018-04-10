using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [Header("Object References")]
    public GameObject enemySpawner;
    public GameController GC;
    public BPM BPM;

    [Header("Waves Lists")]
    public List<GameObject> waveOne;
    public List<GameObject> waveTwo;
    public List<GameObject> waveThree;

    [Header ("Wave Triggers")]
    [SerializeField]
    private float spawnTimer;
    public bool waveActive = false;

    public int waveNumber;

    private void Start()
    {
        GC = GetComponent<GameController>();
        spawnTimer = BPM.timeForBeat;
    }

    void Update()
    {
        spawnTimer = BPM.timeForBeat;
        if (waveActive)
        {
            waveActive = false;
            StartWave();
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
            case 2:
                StartCoroutine(SpawnEnemy(waveThree));
                break;
        }               
    }

    IEnumerator SpawnEnemy(List<GameObject> currentWave)
    {
        GameObject temp;

        foreach (GameObject creep in currentWave)
        {        
            temp = Instantiate(creep, enemySpawner.transform.position, Quaternion.Euler(0, 0, 0), enemySpawner.transform);
            GC.enemies.Add(temp);
            yield return new WaitForSeconds(spawnTimer);         
        }

        ++waveNumber;
    }
}
