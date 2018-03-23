using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{    
    public Transform seeker, target;
    public bool possible;

    public bool triggerPath;

    GridController grid;

    void Awake()
    {
        grid = GetComponent<GridController>();
    }

    void Update()
    {
        //Needs to be changed to on level start && tower being placed
        if (triggerPath)
        {            
            FindPath(seeker.position, target.position);
            triggerPath = false;
        }
    }

    //Find fastest path using A* algorythm
    public void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        //start position
        Node startNode = grid.NodeFromWorldPoint(startPos);
        //end position
        Node targetNode = grid.NodeFromWorldPoint(targetPos);
        
        Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
        //nodes that have bee used
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            //Sets first Node
            Node currentNode = openSet.RemoveFirst();
            closedSet.Add(currentNode);

            //Checks to see if path is finished
            if (currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }           

            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                //Checks to see if neighbour is walkable
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                {                    
                    continue;
                }

                //Adds the nodes g cost to distance to neighbour
                int newCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                //Checks for neighbours current gCost
                if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    //sets neighbolurs costs
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    //Checks for neighbour in openSet
                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                    openSet.UpdateItem(neighbour);
                }                
            }
            if (openSet.Count == 0)
            {
                possible = false;
                return;
            }else
            {
                possible = true;
            }
        }
    }

    //debug fastest route
    void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        //Moves to next node on way to seeker
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        //Reverses list in order to give correct order of path
        path.Reverse();

        //returns the grids optimal path
        grid.path = path;
    }

    //Gets distance of two nodes
    int GetDistance(Node nodeA, Node nodeB)
    {
        //Creates absolute ints of distances
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        //Alters ints for use in A* algorythm
        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}
