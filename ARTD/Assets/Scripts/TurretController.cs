using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    
    [Header("Stats")]
    public float fireRate;
    private float fireCountdown;

    [Header("Game Object References")]
    public EnemySpawn enemySpawn;

    public GameObject bulletPrefab;
	
	// Update is called once per frame
	void Update ()
    {
        enemySpawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawn>();
        GameObject tar = GetClosestEnemy(enemySpawn.enemies);
        if (tar != null)
        {
            transform.LookAt(tar.transform);

            if (fireCountdown <= 0f)
            {
                Shot(tar);
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }     
        
	}

    GameObject GetClosestEnemy(List<GameObject> enemies)
    {
       GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    void Shot(GameObject target)
    {
        Debug.Log("shot");
    }

}
