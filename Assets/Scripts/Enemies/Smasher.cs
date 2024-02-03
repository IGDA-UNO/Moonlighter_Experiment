using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : Enemy
{
    [Range(0f, 5f)]
    public float patrolOffset;
    public int patrolIndex;
    public List<Vector3> patrolLocations;

    


    void Start()
    {
        base.Start();
        ChangeState(EnemyState.PATROL);
        patrolLocations = new List<Vector3>()
        {
            new Vector3(transform.position.x - patrolOffset, transform.position.y - patrolOffset, transform.position.z),
            new Vector3(transform.position.x - patrolOffset, transform.position.y + patrolOffset, transform.position.z),
            new Vector3(transform.position.x + patrolOffset, transform.position.y - patrolOffset, transform.position.z),
            new Vector3(transform.position.x + patrolOffset, transform.position.y + patrolOffset, transform.position.z)

        };

        ShuffleLocations();

        patrolIndex = 0;
    }

    public override void Idle()
    {

    }

    public override void Patrol()
    {
        if (Vector3.Distance(transform.position, patrolLocations[patrolIndex]) <= .001)
        {
            NextLocation();
        }
        //Debug.Log($"Moving to {patrolLocations[patrolIndex]}");
        Debug.DrawRay(transform.position, patrolLocations[patrolIndex] - transform.position, Color.cyan);
        Move(patrolLocations[patrolIndex], "walk");
    }

    public override void Attack()
    {
        if(InAttackRange())
        {
            Smash();
        }
        else
        {
            MoveToAttackRange("run");
        }
    }

    public override void DamagePlayer()
    {
        throw new System.NotImplementedException();
    }

    public void Smash()
    {
        if(attackCooldown >= attackSpeed)
        {
            Debug.Log($"Smashing Player");
            attackCooldown = 0;
        }
        
    }

    private void NextLocation()
    {
        patrolIndex = (patrolIndex + 1) % 4;
    }

    private void ShuffleLocations()
    {
        int end = patrolLocations.Count - 1;
        for(int i = 0; i < patrolLocations.Count; i++)
        {
            if(i == end)
            {
                return;
            }

            Vector3 temp = patrolLocations[i];
            int index = Random.Range(i + 1, end);
            patrolLocations[i] = patrolLocations[index];
            patrolLocations[index] = temp;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            //Debug.Log("Bumped Wall");
            NextLocation();
        }
    }

    // void OnCollisionStay2D(Collision2D other)
    // {
    //     if(other.gameObject.tag == "Wall")
    //     {
    //         //Debug.Log("Bumped Wall");
    //         NextLocation();
    //     }
    // }
}
