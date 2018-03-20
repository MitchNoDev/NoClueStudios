using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUnit : MonoBehaviour {

    [Header("Stats")]
    public int health;

    [Header("Game Object References")]
    public GameObject target;
    public EnemySpawn enemySpawn;

    private NavMeshAgent agent;
	
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Castle");
        enemySpawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawn>();

        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;        
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
