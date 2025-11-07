using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private static Pathfinding instance;
    public static Pathfinding Instance {  get 
        { 
            if (instance == null) 
            {
                instance = new Pathfinding();
            } 
            return instance;
        } }
    public List<Node> FindPath(Vector3 startpos, Vector3 endpos) 
    {
        Node startNode = Grid.Instance.GetNodeFromWorldpos(startpos);
        Node endNode = Grid.Instance.GetNodeFromWorldpos(endpos);
        
        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0) 
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++) 
            {
                if(openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost) 
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if(currentNode == endNode) 
            {
                return RetracePath(startNode,endNode);
            };
            foreach (Node neighbour in Grid.Instance.GetNeighbours(currentNode)) 
            {
                bool hasNode = closedSet.Contains(neighbour);
                if (!neighbour.walkAble || hasNode) 
                {
                    continue;
                }
                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                if(newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) 
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, endNode);
                    neighbour.parent = currentNode;
                    if (!openSet.Contains(neighbour)) 
                    {
                        openSet.Add(neighbour);
                    }
                }
            }
        }
        return null;
    }


    public List<Node> RetracePath(Node startnode,  Node endnode)
    {
        List<Node> path = new List<Node>();
        Node currentnode = endnode;
        while (currentnode != startnode) 
        {
            path.Add(currentnode);
            var tmp = currentnode.parent;
            currentnode.parent = null;
            currentnode.hCost = 0;
            currentnode.gCost = 0;
            currentnode = tmp;
        }
        path.Reverse();
        return path;
    }



    private int GetDistance(Node nodeA, Node nodeB) 
    {
        int dstX = Mathf.Abs(nodeA.gridPosX - nodeB.gridPosX);
        int dstY = Mathf.Abs(nodeA.gridPosY - nodeB.gridPosY);

        if(dstX > dstY) 
        {
            return 14 * dstY + 10 * (dstX - dstY);
        }
        return 14*dstX +  10 * (dstY - dstX);
    }
    
}
