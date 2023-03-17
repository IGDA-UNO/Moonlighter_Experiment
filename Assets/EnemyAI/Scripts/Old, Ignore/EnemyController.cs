using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public enum MovePrioType
    {
        chase,
        stationary,
        // random,
        stayAtDistance,
        flee
    }
public class EnemyController : MonoBehaviour
{
    
    // public UnityEvent TestEvent;
    public GameObject SpriteVisual;
    NavMeshAgent agent;
    simpleMovementAI moveAI;


    public float Speed;
    public MovePrioType MoveType;
    public float StayAtThisDistanceFromTarget;


    private void Start() {
        // TestEvent.Invoke();

        agent = GetComponent<NavMeshAgent>();
        moveAI = GetComponent<simpleMovementAI>();
        
        // simpleMovementAI moveAI = GetComponent<simpleMovementAI>();
        // GetComponent<simpleMovementAI>().econ = this;
        agent.speed = Speed;

        AssignMovePrioType();

        // agent.agentTypeID = 1;

    }

    void AssignMovePrioType(){
        switch (MoveType)
        {
            case MovePrioType.chase:
                moveAI.Moving = true;
                break;
            case MovePrioType.stationary:
                moveAI.Moving = false;
                break;
            
            // case MovePrioType.random:
            //     moveAI.random = true;
            //     break;
            
            case MovePrioType.stayAtDistance:
                moveAI.stayAtDistance = StayAtThisDistanceFromTarget;
                break;
            
            case MovePrioType.flee:
                moveAI.fleeing = true;

                break;
            
            
            default:
                break;


        }
    }


}
