using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Header("Stats")]
    private int damage;

    public float speed = 70f;

    [Header("Game Object References")]
    private GameObject target;

    public void Spawn(GameObject _target, int _damage)
    {
        target = _target;
        damage = _damage;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            //Do Damage
            //set target to null
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

	}

    void HitTarget()
    {
        //Debug.Log("hit something");

        target.GetComponent<EnemyUnit>().health -= damage;

        Destroy(gameObject);
        return;
    }
}
