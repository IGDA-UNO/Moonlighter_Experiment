using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DashDummy : TheDummy
{
    public int mobstate;
    private float transition;
    public float dashtime=4.0f;
    private float decay =0;
    void Start()
    {
        attackTarget = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        attackDamage=0;
    }

    void Update()
    {
        if(DistanceCheck()&&transition<dashtime){
            mobstate = 1;
            transition += Time.deltaTime;
        }
        else if(transition>dashtime){
            mobstate=2;

        }
        else{
            mobstate =0;
        }



        switch(mobstate){
            case 0:
                break;
            case 1:
                agent.SetDestination(attackTarget.position);
                break;
            case 2:
                decaySpeed();
                agent.SetDestination(attackTarget.position);
                break;
        }
    }
    public void decaySpeed(){
        
        decay += Time.deltaTime;
        agent.speed = Mathf.Pow((float)0.8,(float)(2*(decay-3))); // f(t) 0.8^2*(x-3)
        Debug.Log(Mathf.Pow((float)0.8,(float)(2*(decay-3))));
        if(agent.speed < 1.03){
            transition = 0;
            decay = 0;
        }
    }

}
