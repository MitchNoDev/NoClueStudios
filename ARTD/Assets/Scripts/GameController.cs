using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int cash;
    public int baseHealth;
    public int waveNumber;
    public string phaseType;

    public List<GameObject> enemies;

    public PathFinding pathfinding;
    public GridController grid;
    public TurretSpawn turretSpawn;
    public EnemySpawn enemySpawn;
    public BPM BPM;

    [Header("UI")]
    public Text cashText;
    public Text healthText;
    public Text waveText;

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
        if(baseHealth <= 0)
        {
            //GameOver Man
        }

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

        cashText.text = "Cash: " + cash.ToString();
        healthText.text = "Health: " + baseHealth.ToString();
        waveText.text = "Wave: " + waveNumber.ToString();

    }

    public void StartWave()
    {
        turretSpawn.canBuild = false;
        phaseType = "WavePhase";
    }
}
