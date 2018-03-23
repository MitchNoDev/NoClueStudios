using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUnit : MonoBehaviour {

    [Header("Stats")]
    public int health;

    [SerializeField]
    private float jumpTimer;

    [Header("Game Object References")]
    public EnemySpawn enemySpawn;
    public BPM BPM;

    public GridController grid;
    public List<Node> path;

    private int nodeInPath = 0;
    private int endOfPath = 0;
    [SerializeField]
    private Node curNode;
    private Node nextNode;

    private void Awake()
    {        
        enemySpawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawn>();
        grid = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridController>();
        BPM = GameObject.FindGameObjectWithTag("GameController").GetComponent<BPM>();
        path = grid.path;
        jumpTimer = BPM.timeForBeat;
    }

    void Update()
    {
        jumpTimer = BPM.timeForBeat;

        path = grid.path;

        print(path.Count);

        if (health <= 0)
        {            
            StartCoroutine(Die());
            return;
        }

        switch(endOfPath)
        {
            case 0:
                curNode = path[nodeInPath];
                nextNode = path[nodeInPath + 1];
                nodeInPath++;
                endOfPath++;
                print(endOfPath);
                break;
            case 1:
                StartCoroutine("Jump");
                curNode = path[nodeInPath];
                nextNode = path[nodeInPath + 1];
                //nodeInPath++;

                if (curNode == path[path.Count - 2])
                {
                    endOfPath++;
                }
                print(endOfPath);
                break;
            case 2:
                StartCoroutine("Jump");
                endOfPath++;
                print(endOfPath);
                break;
            case 3:
                //deal damage to castle
                StartCoroutine("Die");
                endOfPath++;
                print(endOfPath);
                break;
            case 4:
                print(endOfPath);
                break;
        }

        
    }

    IEnumerator Jump()
    {
        while (true)
        {
            Vector3 tar = nextNode.worldPosition;
            transform.position = tar;

            print("JBegin");
            yield return new WaitForSeconds(jumpTimer);
            print("JEnd");

            nodeInPath++;
            //print(nodeInPath);
        }
    }

    IEnumerator Die()
    {
        enemySpawn.enemies.Remove(gameObject);

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
