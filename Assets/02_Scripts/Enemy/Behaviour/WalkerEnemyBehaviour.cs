using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WalkerEnemyBehaviour : EnemyBehaviour
{
    [SerializeField] private Vector3 debug_Walk_goal = new Vector3(0,0,0);
    [SerializeField] private float moveSpeed = 1000;
    [SerializeField] private float node_Completion_Radius = 0.5f;
    private bool canJump;
    List<Node> currentPath;
    public override void Move(BaseEnemy enemy)
    {
        if(currentPath == null ||  currentPath.Count == 0) 
        {
            int randX = Random.Range(0,Grid.Instance.gridSizeX);
            int randY = Random.Range(0,Grid.Instance.gridSizeY);

            currentPath = Pathfinding.Instance.FindPath(enemy.transform.position, Grid.Instance.grid[randX,randY].worldPos);
        }
        Vector3 dir = currentPath[0].worldPos - enemy.transform.position;
        dir.y = 0;
        dir.Normalize();
        enemy.rigid.linearVelocity = dir *moveSpeed * Time.deltaTime;


        Vector2 pos = new Vector2(enemy.transform.position.x, enemy.transform.position.z);
        Vector2 goal = new Vector2(currentPath[0].worldPos.x, currentPath[0].worldPos.z);

        if(node_Completion_Radius  >= Vector2.Distance(pos,goal)) 
        {
            currentPath.RemoveAt(0);
        }
    }


    private bool DeterminIfCanJump() 
    {
        return false;
    }

    
}
