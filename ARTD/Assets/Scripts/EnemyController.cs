using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public GameObject target;
    public EnemySpawn enemySpawn;

    private NavMeshAgent agent;
	
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Castle");

        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;        
	}
	
    void OnDestroy ()
    {
        enemySpawn.enemies.Remove(this.gameObject);
    }

}
