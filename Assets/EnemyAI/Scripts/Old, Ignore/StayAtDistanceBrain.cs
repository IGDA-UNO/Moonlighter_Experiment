using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Brains/Chase")]
public class StayAtDistanceBrain : Brain
{
    public string targetTag;
    public float stayAtDistance;

    public override void Think(EnemyThinker thinker)
    {
        // GameObject target = GameObject.FindGameObjectWithTag(targetTag);
        // if(target){

            
        //     if(Vector3.Distance(transform.position, target.position) > stayAtDistance){
                
        //         agent.SetDestination(target.transform.position);

        //     } else if(Vector3.Distance(transform.position, target.position) < stayAtDistance){

        //         transform.position = Vector2.MoveTowards(transform.position, target.position, -1 * speed * Time.deltaTime);


        //     }


        // }
    }

}
