using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


using Panda;
namespace Panda.Examples.BrainForEnemyBT
{
    public class BrainForEnemyBT : MonoBehaviour
    {
        
        
        public Transform PlayerTarget;
        public NavMeshAgent agent;

        private void Start() {
            SetupNavMeshAgent();
            if(PlayerTarget == null){
                GameObject playergo = GameObject.FindGameObjectWithTag("Player");
                PlayerTarget = playergo.transform;
            }
        }

        
        void SetupNavMeshAgent(){
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        [Task]
        bool PlayerIsFound{
            get{

                if(PlayerTarget != null){
                    return true;
                }
                // print("returning false for player is found");
                return false;
            }

        }

        
        [Task]
        void MoveToPlayer(){
            // print(" wuld be moving to player right now! ");
            
            agent.SetDestination(PlayerTarget.position);
        
        }

        [Task]
        void Idle(){
            print(" idling right now! ");

        }

        
        [Task]
        void ShootAtPlayer(){
            print(" idling right now! ");

        }

        // void OnCollisionEnter2D(Collision2D coll){
        //     // if colliding with player
        //         // print

        //     // print(" enemy colliding with something! ");

        //     if(coll.gameObject.tag == "Player"){
        //         // print(" colliding with player! ");
        //         coll.gameObject.GetComponent<PlayerDummy>().DeductHealth();
        //         print(" about to add force ");
        //         GetComponent<Rigidbody2D>().AddForce(new Vector2(-7, 2), ForceMode2D.Impulse);
        //         print(" just complete adding to force ");

        //     }

        // }




    }

}
