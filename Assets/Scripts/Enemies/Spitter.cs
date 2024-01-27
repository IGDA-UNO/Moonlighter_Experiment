using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitter : Enemy
{
    

    [Range(0f, 100f)]
    public float fleeRange;

    [Range(0f, 100f)]
    public float attackRange;

    public GameObject projectilePrefab;

    private Transform target;

    private Vector3 roam;

    void Start()
    {
        base.Start();
        state = EnemyState.PATROL;

    }

    public override void Idle()
    {
        
    }

    public override void Patrol()
    {
        LookAround();
    }

    public override void Attack()
    {
        if(InAttackRange())
        {
            Spits();
            Flee();
        }
        else
        {
            MoveToAttackRange();
        }
        
    }

    void Flee()
    {
        if(Vector3.Distance(target.position, transform.position) < fleeRange)
        {
            Vector3 toPlayer = target.position - transform.position;
            Move(toPlayer.normalized * -runSpeed);
        }
    }

    private void LookAround()
    {
        if(Vector3.Distance((Vector2)transform.position, (Vector2)roam)< 0.3f)
        {
            Vector3 walkpos = Random.insideUnitCircle * 3/2; 
            Vector3 newlocation = transform.position + walkpos;
            roam = (Vector2)newlocation; //world space coordinates
            Debug.Log("walking towards" + roam);
            //agent.SetDestination(roam);
        }

        Move(roam);
    }

    private void MoveToAttackRange()
    {
        if(Vector3.Distance(target.position, transform.position) > attackRange)
        {
            Move(target.position);
        }
    }

    public bool InAttackRange()
    {
        float distance = Vector3.Distance(this.transform.position, target.position);
        if(attackRange >= distance)
        {
            return true;
        }
        
        return false;
    }

    void Spits()
    {
        if(attackCooldown >= attackSpeed)
        {
            Instantiate(projectilePrefab, transform.position, computeAngle());
            attackCooldown = 0.0f;
        }
    }

    void Move(Vector3 location)
    {
        Vector3 step = Vector3.MoveTowards(transform.position, location, walkSpeed * Time.fixedDeltaTime);
        physics.MovePosition(step);
    }

    public Quaternion computeAngle()
    {
        float angles = Mathf.Atan2(target.position.y - transform.position.y , target.position.x - transform.position.x) * 180/Mathf.PI;
        return Quaternion.Euler(0f,0f,angles);
        
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
