using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int cash;
    public int waveNumber;
    public string phaseType;

    public List<GameObject> enemies;

    public PathFinding pathfinding;
    public GridController grid;
    public TurretSpawn turretSpawn;
    public EnemySpawn enemySpawn;
    public BPM BPM;

    private void Awake()
    {
        phaseType = "StartPhase";

        pathfinding = GetComponent<PathFinding>();
        grid = GetComponent<GridController>();
        turretSpawn = GetComponent<TurretSpawn>();
        enemySpawn = GetComponent<EnemySpawn>();
        BPM = GetComponent<BPM>();
    }

    private void Update()
    {
        switch(phaseType)
        {
            case "StartPhase":
                //check all is in order for next wave
                phaseType = "BuildPhase";
                break;

            case "BuildPhase":
                turretSpawn.canBuild = true;
                break;

            case "WavePhase":
                enemySpawn.waveActive = true;
                if(enemies.Count == 0)
                {
                    phaseType = "EndPhase";
                }
                break;

            case "EndPhase":
                phaseType = "StartPhase";
                break;

            case "Victory":

                break;
        }
    }

    public void StartWave()
    {
        turretSpawn.canBuild = false;
        phaseType = "WavePhase";
    }
}
