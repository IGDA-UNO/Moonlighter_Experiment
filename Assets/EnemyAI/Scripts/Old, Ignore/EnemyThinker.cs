using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyThinker : MonoBehaviour
{

    public Brain brain;
    public NavMeshAgent agent;

    void Start(){
        SetupNavMeshAgent();

    }

    void Update()
    {
        brain.Think(this);
    }

    void SetupNavMeshAgent(){
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
}
