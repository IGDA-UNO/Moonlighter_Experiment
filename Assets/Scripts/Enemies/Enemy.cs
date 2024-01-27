using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    // Enumerators
    [HideInInspector]
    public enum EnemyState {IDLE, ATTACK, PATROL}

    // Inherited variables
    [SerializeField]
    protected string monsterName;

    [SerializeField, Range(0, 200)]
    protected int health;

    [SerializeField, Range(0f, 100f)]
    protected float walkSpeed;

    [SerializeField, Range(0f, 100f)]
    protected float runSpeed;

    [SerializeField, Range(0f, 100f)]
    protected float attackSpeed;

    [SerializeField, Range(0, 100)]
    protected int attackDamage;

    [SerializeField]
    protected EnemyState state;

    protected NavMeshAgent agent;
    

    // Private
    [HideInInspector]
    protected float attackCooldown;
    [HideInInspector]
    protected Rigidbody2D physics;
    
 
    // Start is called before the first frame update
    protected void Start()
    {
        attackCooldown = attackSpeed;
        physics = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
		agent.updateUpAxis = false;
        agent.speed = walkSpeed;
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

    public void ChangeState(EnemyState newState)
    {
        state = newState;
    }
    
}
