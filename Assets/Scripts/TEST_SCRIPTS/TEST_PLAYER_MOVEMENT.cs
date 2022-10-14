using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_PLAYER_MOVEMENT : MonoBehaviour
{

    public int gold;
    public int health;
    public int maxHealth;

    public float playerSpeed = .001f;

    //float yMovement;
    //float xMovement;

    //Making this a vector 3 makes it easier to adjust the player's transform.
    Vector3 movementChange = new Vector3();

    private Animator animator;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        maxHealth = 100;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hello, World!");

        movementChange = Vector3.zero; // we need to clear out old inputs each frame!
        movementChange.x = Input.GetAxisRaw("Horizontal");
        movementChange.y = Input.GetAxisRaw("Vertical");
    
        



        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(AttackCoroutine());
        }


    }

    void FixedUpdate(){
        //we need to know if we are 'walking' or if we are 'idle'
        if(movementChange == Vector3.zero){
            //neiher moving up nor down -- we must be idle!
            animator.SetBool("isMoving", false);
        }
        else{
            //update the blend tree for animations
            MoveCharacter();
            animator.SetFloat("moveX", movementChange.x);
            animator.SetFloat("moveY", movementChange.y);
            animator.SetBool("isMoving", true);
        }
    }

    private IEnumerator AttackCoroutine(){
            Debug.Log("attack!");
            animator.SetBool("isAttacking", true);
            yield return null;
            animator.SetBool("isAttacking", false);
    }

    public void MoveCharacter(){
        rigidBody.MovePosition(
            this.transform.position + (movementChange * playerSpeed * Time.deltaTime)
        );
    }
}
