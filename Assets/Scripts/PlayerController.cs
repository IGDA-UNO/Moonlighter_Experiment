using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //THIS IS THE UP TO DATE PLAYER SCRIPT
    public int gold;
    public int health;
    public int maxHealth;

    //Does the weapon need to be something you can specify here?
    public PlayerHit currentWeapon; 

    private Rigidbody2D myRigidBody;
    private Animator myAnimator;


    [SerializeField] private float playerSpeed; // = 1f;

    Vector3 movementChange = new Vector3();

    //Audio sources
    
    //public AudioSource swordSFX;
    //public AudioSource walkSFX;



    // Start is called before the first frame update
    void Awake()
    {
        maxHealth = 100;
        health = maxHealth;
    }

    void Start()
    {   
        Debug.Log(transform.position);
       
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        playerSpeed = 120f;

        //swordSFX = GetComponent<AudioSource>();
        //walkSFX = GetComponent<AudioSource>();

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
            //walkSFX.Play();
        }
        else{
            myAnimator.SetBool("isMoving", false);
        }

        //handle player attacking
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(AttackCoroutine());
            
            //swordSFX.Play();
            
        }

    }

    //start the attack animation
    IEnumerator AttackCoroutine(){
        //this animation activates hitboxes.
        //see the player's animation.
        Debug.Log("attack!");
        myAnimator.SetBool("isAttacking", true);
        yield return null;
        myAnimator.SetBool("isAttacking", false);
    }

    public int getHealth(){
        return this.health;
    }

    public void setHealth(int health){
        Debug.Log("Health: " + health);
        this.health = health;
    }

    public void killPlayer()
    {   //RIP player
        //the player being destroyed may be better managed elsewhere,
        //especially outside the player.
        //see the TakeDamage method.
        if (health <= 0)
        {
            Debug.Log("Health: " + health);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        this.health -= amount;
        Debug.Log($"I have taken {amount} damage!");


        //should killPlayer be managed elsewhere?
        killPlayer();
    }

    public void healAction(){
        //it might be wise to tie this to some resource
        int healingAmount = 10;

        //instead of having a fixed amount, if for example it uses 
        //an inventory system, maybe different healing potions
        //may heal different amounts.
        this.setHealth(healingAmount + this.getHealth());

    }

}
