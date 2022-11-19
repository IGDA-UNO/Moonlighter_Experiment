using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TheDummy : Enemy
{
    public int dummyPoints;
    public float chaseRadius;
    public float attackRadius;
    public int playerhealth;
    public Transform attackTarget;

    private Rigidbody2D myRigidBody;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        attackTarget = GameObject.FindGameObjectWithTag("Player").transform;
        playerhealth = attackTarget.GetComponent<PlayerController>().getHealth();
        myRigidBody = GetComponent<Rigidbody2D>();
        attackDamage = 50;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        DistanceCheck();
        

     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("A collision occured.");
            if (other.gameObject.tag =="Player")
            {
            //change health of player 
            playerhealth = playerhealth - attackDamage;
            Debug.Log("The player has less health.");
            attackTarget.GetComponent<PlayerController>().setHealth(playerhealth);
            }

            else
            {
                //player health stays the same 
                playerhealth = playerhealth;
            }

    }
    


    //check the distance between this Dummy and the player.
    void DistanceCheck(){
        float distance = Vector3.Distance(this.transform.position, attackTarget.position);

        if(distance < chaseRadius){
            //Vector3 newLocation = Vector3.MoveTowards(this.transform.position, attackTarget.position, moveSpeed * Time.deltaTime);
            //myRigidBody.MovePosition(newLocation);
            agent.SetDestination(attackTarget.position);

        }
    }

   
}
