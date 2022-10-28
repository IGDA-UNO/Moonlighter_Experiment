using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int gold;
    public int health;
    public int maxHealth;

    private Rigidbody2D myRigidBody;
    private Animator myAnimator;


    [SerializeField] private float playerSpeed; // = 1f;

    Vector3 movementChange = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
        maxHealth = 100;
        health = maxHealth;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        playerSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hello, World!");

        movementChange.x = Input.GetAxisRaw("Horizontal");
        movementChange.y = Input.GetAxisRaw("Vertical");

        //Debug.Log("xMovement is: " + movementChange.x);
    
        if(movementChange != Vector3.zero){
            myAnimator.SetFloat("moveX", movementChange.x);
            myAnimator.SetFloat("moveY", movementChange.y);
            myAnimator.SetBool("isMoving", true);
            myRigidBody.MovePosition(
                this.transform.position + (movementChange * playerSpeed * Time.deltaTime)
            );
        }
        else{
            myAnimator.SetBool("isMoving", false);
        }

        //handle player attacking
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(AttackCoroutine());
        }

        //RIP player
        if (health <= 0) {
            Destroy(gameObject);
        }

    }

    IEnumerator AttackCoroutine(){
        Debug.Log("attack!");
        myAnimator.SetBool("isAttacking", true);
        yield return null;
        myAnimator.SetBool("isAttacking", false);
    }

    public int getHealth(){
        return this.health;
    }

    public void setHealth(int health){
        this.health = health;
    }
}
