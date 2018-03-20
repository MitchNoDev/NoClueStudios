using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour {
    
    public GameObject turretPrefab;
    public PathFinding pathfinding;
    public GridController grid;
    bool nodeSelected;

    public Vector3 spawnOffset;

    private void Start()
    {
        pathfinding = GetComponent<PathFinding>();
        grid = GetComponent<GridController>();
    }

    void Update ()
    {	
        if (Input.GetMouseButtonDown(0) && !nodeSelected)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Transform objectHit = hit.transform;

                objectHit.gameObject.layer = 8;
                grid.FillGrid();
                pathfinding.triggerPath = true;
            }
        }
        if (Input.GetMouseButtonDown(0) && nodeSelected)
        { RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Transform objectHit = hit.transform;

               
                if (objectHit.gameObject.tag == "Turret Spawn")
                {
                    SpawnTurret(objectHit.gameObject);
                }
            }
        }
	}

    void SpawnTurret(GameObject objHit)
    {       

        if (pathfinding.possible)
        {
            Debug.Log("bad");
            Instantiate(turretPrefab, position: (objHit.transform.position + spawnOffset), rotation: Quaternion.Euler(0, 0, 0), parent: objHit.transform);            
        }else
        {
            Debug.Log("Good");
            objHit.layer = 0;
            grid.FillGrid();
            pathfinding.triggerPath = true;
        }       

    }
}
