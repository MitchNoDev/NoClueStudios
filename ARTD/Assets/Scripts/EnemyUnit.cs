using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUnit : MonoBehaviour {

    [Header("Stats")]
    public int health;

    [Header("Game Object References")]
    public EnemySpawn enemySpawn;
	
	void Start ()
    {
        enemySpawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawn>();   
	}

    void Update()
    {
        if(health <= 0)
        {
            //Debug.Log("ding");
            enemySpawn.enemies.Remove(gameObject);
            Destroy(gameObject);
            return;
        }
    }
}
