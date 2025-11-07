using UnityEngine;
[System.Serializable]
public class Node
{
    public bool walkAble;
    public Vector3 worldPos;
    public int gridPosX;
    public int gridPosY;
    public int gCost;
    public int hCost;
    public Node parent;
    public int fCost
    {
        get { return gCost + hCost; }
    }

    public Node()
    {
    }

    public Node(bool walkAble, Vector3 worldPos)
    {
        this.walkAble = walkAble;
        this.worldPos = worldPos;
    }

    public Node(bool walkAble, Vector3 worldPos, int gridPosX, int gridPosY)
    {
        this.walkAble = walkAble;
        this.worldPos = worldPos;
        this.gridPosX = gridPosX;
        this.gridPosY = gridPosY;
    }
}
