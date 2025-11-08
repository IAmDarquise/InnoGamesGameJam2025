using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour, IHitable
{
    public float maxHp;
    private float currentHP;
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

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if(currentHP <= 0) 
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        currentHP = maxHp;
        behaviour.Move(this);
    }
}
