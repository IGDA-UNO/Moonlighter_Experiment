using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDummy : Enemy
{
    public int dummyPoints;

    //public int attackDamage;
    public int playerhealth;

    public float chaseRadius;
    public float attackRadius;

    public Transform attackTarget;

    private Rigidbody2D myRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        attackTarget = GameObject.FindGameObjectWithTag("Player").transform;
        playerhealth = GetComponent<PlayerController>().health;
        myRigidBody = GetComponent<Rigidbody2D>();
        attackDamage = 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DistanceCheck();
        

     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag =="Player")
            {
            //change health of player 
            playerhealth = playerhealth - attackDamage ;
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
            Vector3 newLocation = Vector3.MoveTowards(this.transform.position, attackTarget.position, moveSpeed * Time.deltaTime);
            myRigidBody.MovePosition(newLocation);
        }
    }

   
}
