
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AStarGrid : MonoBehaviour
{
    private static AStarGrid instance;
    public static AStarGrid Instance {  get { return instance; } } 
    [SerializeField] private Vector3 debug_vector3_playerPos = Vector3.zero;
    public LayerMask unwalkableMask;
    public Vector2 worldGridSize;
    public float nodeRadius;
    [SerializeField] public Node[,] grid;

    float nodeDiameter;
    public int gridSizeX, gridSizeY;

    private void Awake()
    {
        if(instance == null || instance == this) 
        {
            instance = this;
            InitGrid();
            return;
        }
        Destroy(gameObject);
    }
    private void CreateGrid() 
    {
        grid = new Node[gridSizeX,gridSizeY];
        Vector3 worldBottomLeft = transform.position -Vector3.right * worldGridSize.x/2 - Vector3.forward * worldGridSize.y/2;
        
        for (int x = 0; x < gridSizeX; x++) 
        {
            for (int y = 0; y < gridSizeY; y++) 
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !Physics.CheckSphere(worldPoint,nodeDiameter,unwalkableMask);
                grid[x, y] = new Node(walkable,worldPoint,x,y);
            }
        }
    }
    [ContextMenu("InitGrid")]
    private void InitGrid() 
    {
        nodeDiameter = nodeRadius*2;
        gridSizeX = Mathf.RoundToInt( worldGridSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt( worldGridSize.y / nodeDiameter);
        CreateGrid();
    }

    public Node GetNodeFromWorldpos(Vector3 worldPosition) 
    {
        float percentX = (worldPosition.x + worldGridSize.x / 2) / worldGridSize.x;
        float percentY = (worldPosition.z + worldGridSize.y / 2) / worldGridSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX-1)*percentX);
        int y = Mathf.RoundToInt((gridSizeY-1)*percentY);
        return grid[x, y];
    }

    

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(worldGridSize.x, 1, worldGridSize.y));
        if(grid == null) 
        {
            return;
        }
        foreach(Node node in grid) 
        {
            Gizmos.color = node.walkAble? Color.wheat : Color.red;
            Gizmos.DrawCube(node.worldPos, Vector3.one * (nodeDiameter - 0.1f));
        }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();


        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }
                int checkX = node.gridPosX + x;
                int checkY = node.gridPosY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(grid[checkX,checkY]);
                }

            }

        }

        return neighbours;
    }
}
