using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OldSpitter : MonoBehaviour
{   public GameObject SpitFacts;
    public float spitRate = 5.0f;
    private float spitTimers = 0.0f;
    public float chaseRadius;
    public Transform attackTarget;
    private Rigidbody2D ThisRigid;
    public float attackRadius;
    private Vector3 spawnPos;
    private int mobstate;
    private Vector3 roam;
    private NavMeshAgent agent;


    
    // Start is called before the first frame update
    void Start()
    {
        
        attackTarget = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
        agent.updateUpAxis = false;
        lookAround();
        ThisRigid = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;
        roam = spawnPos;
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if(DistanceCheck()){
            mobstate = 1; //attacking and fleeing
        }
        else if(isInrangeAttack()){
            mobstate=2;
        }
        else{
            mobstate = 0; //attacking but not fleeing
        }

        switch(mobstate){
            case -1:
            lookAround();
            break;
            case 0:
                walkAround(roam);
                agent.isStopped = false;
                break;
            case 1:
                Spits();
                flee();
                agent.isStopped = false;
                break;
            case 2:
                Spits();
                agent.isStopped = true;
                break;
        }
        

    }

    //Spitting action happen here
    void Spits(){
        spitTimers += Time.deltaTime;
        if(spitTimers > spitRate){
            Instantiate(SpitFacts, transform.position, computeAngle());
            spitTimers = 0.0f;
        }
    }

    //check distance return the boolean if player is in range
    public bool DistanceCheck(){
        float distance = Vector3.Distance(this.transform.position, attackTarget.position);
        if(chaseRadius >= distance){
            return true;
        }
        else{
            return false;
        }
    }
    public bool isInrangeAttack(){
        float distance = Vector3.Distance(this.transform.position, attackTarget.position);
        if(attackRadius >= distance){
            return true;
        }
        else{
            return false;
        }
    }

    void flee(){
            Vector3 localposition = transform.InverseTransformPoint(attackTarget.position);
            //Vector3 newLocation = Vector3.MoveTowards(Vector3.zero, localposition, moveSpeed * Time.deltaTime);
            agent.SetDestination(transform.position + localposition * -1);
            //Vector3 step = Vector3.MoveTowards(transform.position,agent.nextPosition, moveSpeed*Time.deltaTime);
            //ThisRigid.MovePosition(step);
    }

    public Quaternion computeAngle(){
         float angles = Mathf.Atan2(attackTarget.position.y - transform.position.y , attackTarget.position.x - transform.position.x) * 180/Mathf.PI;
        return Quaternion.Euler(0f,0f,angles);
        
    }
    
    private Vector3 lookAround(){
        if(Vector3.Distance((Vector2)transform.position, (Vector2)roam)< 0.3f){
        Vector3 walkpos = Random.insideUnitCircle * 3/2; 
        Vector3 newlocation = spawnPos + walkpos;
         roam = (Vector2)newlocation; //world space coordinates
         Debug.Log("walking towards" + roam);
         mobstate = 0;
        }
         return roam;


    }
    void walkAround(Vector3 destination){
        if(Vector3.Distance((Vector2)transform.position, (Vector2)destination)>= 0.3f){
            agent.SetDestination(destination);
            //Vector3 step2des = Vector3.MoveTowards(this.transform.position, agent.nextPosition, moveSpeed * Time.deltaTime);
            //ThisRigid.MovePosition(step2des);
            
            
            
        }
        else{

            Invoke("lookAround",3f);
        }
         
    }
    

}
