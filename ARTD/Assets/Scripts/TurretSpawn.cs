﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour {
    
    public GameObject turretPrefab;
    public PathFinding pathfinding;
    public GridController grid;
    public GameController GC;
    bool nodeSelected;

    public Vector3 spawnOffset;

    public GameObject selectedNode;

    public bool canBuild;

    private void Start()
    {
        pathfinding = GetComponent<PathFinding>();
        grid = GetComponent<GridController>();
        GC = GetComponent<GameController>();
    }

    void Update()
    {
        if (canBuild)
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
                        selectedNode.GetComponent<NodeController>().towerOn = true;
                        selectedNode.GetComponent<NodeController>().trigger = true;
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
    }

    void SpawnTurret(GameObject objHit)
    {       
        if (pathfinding.possible)
        {
            Instantiate(turretPrefab, position: (objHit.transform.position + spawnOffset), rotation: Quaternion.Euler(0, 0, 0), parent: objHit.transform);
            selectedNode = null;
        }
    }
}
