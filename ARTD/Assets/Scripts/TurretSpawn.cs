using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour {
    
    public GameObject turretPrefab;
    public PathFinding pathfinding;
    public GridController grid;
    bool nodeSelected;

    public Vector3 spawnOffset;

    public GameObject selectedNode;

    private void Start()
    {
        pathfinding = GetComponent<PathFinding>();
        grid = GetComponent<GridController>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            GameObject objectHit = hit.transform.gameObject;

            if (Input.GetMouseButtonDown(0) && objectHit.tag == "Turret Spawn")
            {
                if (selectedNode == null)
                {
                    selectedNode = objectHit;
                    selectedNode.layer = 8;

                    grid.FillGrid();
                    pathfinding.triggerPath = true;
                }
                else if (selectedNode != null && selectedNode != objectHit)
                {
                    selectedNode.layer = 0;
                    selectedNode = objectHit;
                    selectedNode.layer = 8;

                    grid.FillGrid();
                    pathfinding.triggerPath = true;
                }
                else if (selectedNode != null && selectedNode == objectHit)
                {
                    SpawnTurret(selectedNode);
                }
            }            
        }

        if (Input.GetMouseButtonDown(1) && selectedNode != null)
        {
            selectedNode.layer = 0;
            selectedNode = null;

            grid.FillGrid();
            pathfinding.triggerPath = true;
        }
    }

    void SpawnTurret(GameObject objHit)
    {       
        if (pathfinding.possible)
        {
            Instantiate(turretPrefab, position: (objHit.transform.position + spawnOffset), rotation: Quaternion.Euler(0, 0, 0), parent: objHit.transform);            
        }else
        {
            objHit.layer = 0;
            grid.FillGrid();
            pathfinding.triggerPath = true;
        }
    }
}
