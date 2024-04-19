using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[System.Serializable]
public class EnemyDeath : UnityEvent<string> { }

public abstract class Enemy : MonoBehaviour
{
    // Enumerators
    [HideInInspector]
    public enum EnemyState {IDLE, ATTACK, PATROL}

    // Inherited variables
    [SerializeField]
    protected string monsterName;

    [SerializeField, Range(0, 500)]
    protected int health;

    [SerializeField, Range(0f, 100f)]
    protected float walkSpeed;

    [SerializeField, Range(0f, 100f)]
    protected float runSpeed;

    [SerializeField, Range(0f, 100f)]
    protected float attackSpeed;

    [SerializeField, Range(0, 100)]
    protected int attackDamage;

    [Range(0f, 100f)]
    public float attackRange;

    public EnemyDeath enemyDies;
    

    // Private
    [HideInInspector]
    protected EnemyState state;
    [HideInInspector]
    protected float attackCooldown;
    [HideInInspector]
    protected Rigidbody2D physics;
    [HideInInspector]
    protected Transform target;
    
 
    // Start is called before the first frame update
    protected void Start()
    {
        attackCooldown = attackSpeed;
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown += Time.deltaTime;

        switch (state)
        {
            case EnemyState.ATTACK:
                Attack();
                break;
        }
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case EnemyState.IDLE:
                Idle();
                break;
            case EnemyState.PATROL:
                Patrol();
                break;
        }
    }

    public abstract void Idle();

    public abstract void Patrol();

    public abstract void Attack();

    public abstract void DamagePlayer();

    public abstract void Dies();

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            enemyDies.Invoke(monsterName);
            Dies();
        }
    }

    public void ChangeState(EnemyState newState)
    {
        state = newState;
    }

    protected void Move(Vector3 location, string type)
    {
        Vector3 step = Vector3.zero;
        switch (type)
        {
            case "walk":
                step = Vector3.MoveTowards(transform.position, location, walkSpeed * Time.fixedDeltaTime);
                break;
            case "run":
                step = Vector3.MoveTowards(transform.position, location, runSpeed * Time.fixedDeltaTime);
                break;
        }
        physics.MovePosition(step);
    }

    protected void MoveToAttackRange(string type)
    {
        if(Vector3.Distance(target.position, transform.position) > attackRange)
        {
            Move(target.position, type);
        }
    }

    protected bool InAttackRange()
    {
        if(Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            return true;
        }
        
        return false;
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.transform;
            Debug.Log("Player Detected");
            ChangeState(EnemyState.ATTACK);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = null;
            ChangeState(EnemyState.PATROL);
        }
    }
}
