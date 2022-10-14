using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ENEMY_SQUARE : TEST_ENEMY
{

    public Transform target;
    public Transform home;

    public float chaseRadius;
    public float attackRadius;

    private Rigidbody2D myRigidBody;

    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        myRigidBody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckDistance();
        if(enemyState == EnemyState.idle){
            mySpriteRenderer.color = Color.white;
        }
        else if(enemyState == EnemyState.walk){
            mySpriteRenderer.color = Color.yellow;
        }
        else if(enemyState == EnemyState.attack){
            mySpriteRenderer.color = Color.red;
        }
    }

    void FixedUpdate(){
        CheckDistance();
    }

    void CheckDistance(){
        float distance = Vector3.Distance(target.position, this.transform.position);
        if( distance <= chaseRadius && distance > attackRadius){
            this.enemyState = EnemyState.walk;
            //start chasing!
            Vector3 toMove = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed*Time.deltaTime);
            myRigidBody.MovePosition(toMove);
        }
        else if(distance < attackRadius){
            this.enemyState = EnemyState.attack;
        }
        else if(distance > chaseRadius){
            this.enemyState = EnemyState.walk;
            Vector3 toMove = Vector3.MoveTowards(this.transform.position, home.position, moveSpeed*Time.deltaTime);
            myRigidBody.MovePosition(toMove);
        }
        if(Vector3.Distance(transform.position, home.position) < 0.1f){
            Debug.Log("IDLE IDLE IDLE");
            this.enemyState = EnemyState.idle;
        }
    }
}
