using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour, IHitable
{
    [SerializeField] private MonoBehaviour enemyVis;
    [SerializeField] private LayerMask propLayer;
    [SerializeField] private Animator anim;
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

    private void Awake()
    {
        ResetValues();
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
            enemyVis.enabled = false;
            WaveSystem.Instance?.EnemyDied(this);
            isDead = true;
            Destroy(gameObject);
            gameObject.layer = LayerMask.NameToLayer("Props");
            anim.speed = 0;
            enemyVis.transform.LookAt(enemyVis.transform.position + new Vector3(0, 1, 0));

            enemyVis.transform.localPosition = new Vector3(0, -0.45f + Random.Range(0.0000001f, 1f), 0);
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<Collider>());
        }
    }

    public void ResetValues()
    {
        currentHP = maxHp;
        isDead = false;
        behaviour?.Move(this);
        Attack();
    }


    private async void Attack() 
    {
        if(this == null) 
        {
            return;
        }

        if (player == null) 
        {
            await Task.Delay(attackCheckInterval);
            Attack();
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
