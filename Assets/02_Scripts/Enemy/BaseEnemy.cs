using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    [SerializeField] private EnemyBehaviour behaviour;
    public Rigidbody rigid;
    public void SetBehaviour(EnemyBehaviour newBehaviour) 
    {
        behaviour = newBehaviour;
    }
    private void Start()
    {
        behaviour = new WalkerEnemyBehaviour();
        behaviour.Move(this);
    }

    
}
