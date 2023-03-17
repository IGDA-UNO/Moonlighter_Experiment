using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Brains/Chase")]
public class ChaseBrain : Brain
{
    public string targetTag;

    public override void Think(EnemyThinker thinker)
    {
        GameObject target = GameObject.FindGameObjectWithTag(targetTag);
        if(target){
            thinker.agent.SetDestination(target.transform.position);
        }
    }

}
