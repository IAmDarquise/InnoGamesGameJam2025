using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] public Transform m_Target;
    [SerializeField] private EnemyBehaviour behaviour;
    public Rigidbody rigid;
    public List<Node> path;
    public void SetBehaviour(EnemyBehaviour newBehaviour) 
    {
        behaviour = newBehaviour;
    }
    private void Start()
    {
        behaviour = new WalkerEnemyBehaviour();
    }

    public void Update()
    {
        behaviour.Move(this);
    }

    private void OnDrawGizmos()
    {
        foreach (var node in path) 
        {
            Gizmos.color = Color.purple;
            Gizmos.DrawWireCube(node.worldPos, Vector3.one * AStarGrid.Instance.nodeRadius);
        }
    }
}
