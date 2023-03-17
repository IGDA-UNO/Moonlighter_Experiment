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
            // attaches this enemy to the navmesh, makes it able to know where its going
            SetupNavMeshAgent();

            // if there is no player target, get it
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



        // when called, wull return true if there is a player this enemy is hunting
        [Task]
        bool PlayerIsFound{
            get{

                if(PlayerTarget != null){
                    return true;
                }
                return false;
            }

        }

        
        // sets the destination for this navmesh agent to the player's position
        [Task]
        void MoveToPlayer(){
            
            agent.SetDestination(PlayerTarget.position);
        
        }

        // do nothing, just print a statement
        [Task]
        void Idle(){
            print(" idling right now! ");

        }

        
        // going to shoot a projectile
        [Task]
        void ShootAtPlayer(){
            print(" Trying to shoot at player! ");

        }

        // will make the sprite blink quickly
        [Task]
        void BlinkSprite(){
            print(" Trying to Blink this sprite! ");

        }

        // destroys this object
        [Task]
        void Die(){
            print(" Guess ill die! ");
            Destroy(this.gameObject);

        }






    }

}
