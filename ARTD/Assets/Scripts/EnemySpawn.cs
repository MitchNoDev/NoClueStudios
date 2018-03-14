using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemySpawner;
    public GameObject enemyPrefab;

    public List<GameObject> enemies;

    [SerializeField]
    private float spawnTimer = 2f;
    private float timer = 0f;

    public int waveNumber;
	
	void Update ()
    {
        //Timer for spawn delay
        timer += Time.deltaTime;
        if(timer >= spawnTimer)
        {
            Debug.Log("Spawn");
            SpawnEnemy();
        }
	}

    void SpawnEnemy()
    {
        GameObject temp;
        //Case system for waves
        switch (waveNumber)
        {            
            //first wave
            case 0:
                temp = Instantiate(enemyPrefab, enemySpawner.transform.position, Quaternion.Euler(0, 0, 0), enemySpawner.transform);
                enemies.Add(temp);
                break;
            //Second wave
            case 1:
                temp = Instantiate(enemyPrefab, enemySpawner.transform.position, Quaternion.Euler(0, 0, 0), enemySpawner.transform);
                enemies.Add(temp);
                break;
        }

        //Increment Wave
        ++waveNumber;

        //Reset timer
        timer = 0f;
    }
}
