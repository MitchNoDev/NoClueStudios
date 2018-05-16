using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUnit : MonoBehaviour {

    [Header("Stats")]
    public int health;

    [Header("Game Object References")]
    public EnemySpawn enemySpawn;
    public BPM BPM;
    public GameController GC;

    public GridController grid;
    public List<Node> path;

    private int nodeInPath = 0;
    private int endOfPath = 0;

    private Node curNode;
    private Node nextNode;

    private void Awake()
    {        
        grid = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridController>();
        BPM = GameObject.FindGameObjectWithTag("GameController").GetComponent<BPM>();
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        path = grid.path;
    }

    void Update()
    {
        path = grid.path;

        if (health <= 0)
        {            
            StartCoroutine("Die");
            return;
        }

        switch(endOfPath)
        {
            case 0:
                curNode = path[nodeInPath];
                nextNode = path[nodeInPath];
                endOfPath++;
                break;
            case 1:
                Jump();

                if (curNode == path[path.Count - 2])
                {
                    endOfPath++;
                }                
                break;
            case 2:
                StartCoroutine("Die");
                endOfPath++;
                break;
        }

        
    }

    void Jump()
    {
        if (BPM.trigger)
        {
            Vector3 tar = nextNode.worldPosition;
            transform.position = tar;

            curNode = path[nodeInPath];
            nextNode = path[nodeInPath + 1];
            nodeInPath++;
        }
    }

    IEnumerator Die()
    {
        GC.enemies.Remove(gameObject);
        GC.baseHealth -= 1;

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
