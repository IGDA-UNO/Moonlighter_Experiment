using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class simpleMovementAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    EnemyController econ;
    public bool Moving;
    public bool fleeing;
    // public bool random;
    public float stayAtDistance;
    Vector3 TargetPosition;

    public bool Destination;
    public bool MoveInDirection;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        econ = this.transform.GetComponent<EnemyController>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        SetTargetPosition();





    }

    private void Update() {
        SetTargetPosition();
        if(Moving){
            if(Destination){
                agent.SetDestination(TargetPosition);
            } else if (MoveInDirection){
                // agent.Move();

            }
        }
    }

    void SetTargetPosition(){

        if(fleeing){
            TargetPosition = transform.position - target.position;
            return;
        }

        if(stayAtDistance > 0){
            MoveInDirection = true;

            if(Vector3.Distance(transform.position, target.position) > stayAtDistance)
            {
                //some follow logic here
                agent.Move(Vector3.Normalize(transform.position - target.position) * Time.deltaTime);
            } else if(Vector3.Distance(transform.position, target.position) < stayAtDistance)
            {
                //some follow logic here
                agent.Move(target.position * -1);
            } else {
                TargetPosition = transform.position;
            }
            
            return;
            
        }


        // if chasing
        TargetPosition = target.position;



        

    }



}
