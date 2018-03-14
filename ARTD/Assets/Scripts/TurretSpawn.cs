using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour {
    
    public GameObject turretPrefab;

	void Update ()
    {		
        //Check for left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                //sets hit transform for spawn
                Transform objectHit = hit.transform;
                //Check for raycast target tag
                if (hit.transform.gameObject.tag == "Turret Spawn")
                {
                    //Spawns turret
                    //Going to be changed to radial menu of turret types
                    Instantiate(turretPrefab, position: (objectHit.transform.position), rotation: Quaternion.Euler(0,0,0), parent: objectHit.transform);
                }
            }
        }
	}
}
