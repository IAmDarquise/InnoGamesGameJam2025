using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour, IHitable
{
    public float maxHp;
    private float currentHP;
    public float speed;
    public NavMeshAgent agent;
    public Transform target;
    public PlayerHealth player; 
    [SerializeField] private EnemyBehaviour behaviour;
    public Rigidbody rigid;
    public int attackIntervalMS = 1000;
    public int attackCheckInterval = 200;
    public float attackRange;
    public float damage;
    private bool isDead = false;
    
    public void SetTarget(Transform targetToHunt) 
    {
        target = targetToHunt;
    }
    
    public void SetBehaviour(EnemyBehaviour newBehaviour) 
    {
        behaviour = newBehaviour;
    }
    private void Start()
    {
        behaviour = new WalkerEnemyBehaviour();
        behaviour.Move(this);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0) 
        {
            WaveSystem.Instance.EnemyDied(this);
            isDead = true;
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        currentHP = maxHp;
        isDead = false;
        behaviour?.Move(this);
        Attack();
    }


    private async void Attack() 
    {
        if (isDead) 
        {
            return;
        }

        if(!(Vector3.Distance( transform.position,player.gameObject.transform.position) <= attackRange)) 
        {
            await Task.Delay(attackCheckInterval);
            Attack();
            return;
        }
        player.TakeDamage(damage);
        await Task.Delay(attackIntervalMS);
        Attack();

    }
}
