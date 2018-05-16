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

    private int count = 0;

    public int waveNumber;

    private void Start()
    {
        GC = GetComponent<GameController>();
        BPM = GetComponent<BPM>();
    }

    void Update()
    {
        StartWave();
    }

    void StartWave()
    {        
        //Case system for waves
        switch (waveNumber)
        {            
            //first wave
            case 0:
                SpawnEnemy(waveOne);
                break;
            //Second wave
            case 1:
                SpawnEnemy(waveTwo);
                break;
            case 2:
                SpawnEnemy(waveThree);
                break;
        }               
    }

    void SpawnEnemy(List<GameObject> currentWave)
    {
        GameObject temp;
        while (count != currentWave.Count)
        {
            if (BPM.trigger)
            {
                temp = Instantiate(currentWave[count], enemySpawner.transform.position, Quaternion.Euler(0, 0, 0), enemySpawner.transform);
                GC.enemies.Add(temp);
                count += 1;
            }
        }

        ++waveNumber;
    }
}
