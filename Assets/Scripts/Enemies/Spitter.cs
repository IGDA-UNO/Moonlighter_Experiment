using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitter : Enemy
{
    

    [Range(0f, 100f)]
    public float fleeRange;

    public GameObject projectilePrefab;

    private Vector3 roam;

    void Start()
    {
        base.Start();
        roam = transform.position;
        ChangeState(EnemyState.PATROL);

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
            MoveToAttackRange("walk");
        }
        
    }

    public override void DamagePlayer()
    {
        throw new System.NotImplementedException();
    }

    public override void Dies()
    {
        
    }

    void Flee()
    {
        if(Vector3.Distance(target.position, transform.position) < fleeRange)
        {
            Vector3 toPlayer = target.position - transform.position;
            Move(toPlayer.normalized * -runSpeed, "walk");
        }
    }

    private void LookAround()
    {
        if(Vector3.Distance(transform.position, roam) < 0.1f)
        {
            NewRoamLocation();
        }
        Debug.DrawRay(transform.position, roam - transform.position, Color.cyan);
        Move(roam, "walk");
    }

    
    void Spits()
    {
        if(attackCooldown >= attackSpeed)
        {
            Instantiate(projectilePrefab, transform.position, computeAngle());
            attackCooldown = 0.0f;
        }
    }

    void NewRoamLocation()
    {
        Vector3 walkpos = Random.insideUnitCircle;
        Debug.Log(walkpos);
        Vector3 newlocation = transform.position + walkpos;
        roam = newlocation;
        
        //Debug.Log($"Walking towards {roam}");
    }

    public Quaternion computeAngle()
    {
        float angles = Mathf.Atan2(target.position.y - transform.position.y , target.position.x - transform.position.x) * 180/Mathf.PI;
        return Quaternion.Euler(0f,0f,angles);
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            //Debug.Log("Bumped Wall");
            NewRoamLocation();
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            //Debug.Log("Bumped Wall");
            NewRoamLocation();
        }
    }

}
