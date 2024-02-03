using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestController : MonoBehaviour
{
    //indicates if this is a fetch quest. if its not, its a kill quest.
    private int isFetch;
    //true if the player is in range of the quest giver
    private bool isInRange; 
    //stores the gold reward for a quest
    private int reward;   
    
    //stores transform of player and then quest giver
    [SerializeField] private Vector3 playerPos;
    [SerializeField] private Vector3 questGiverPos;

    //stores distance of the player 
    [SerializeField] private float playerDistance;
    //distance required for quest activation
    public float activationDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Find the location of the player and quest giver
        playerPos = GameObject.FindWithTag("Player").transform.position;
        questGiverPos = GameObject.Find("QuestGiver").transform.position;

        //find the distance between the player and the quest giver
        playerDistance = Vector3.Distance(playerPos, questGiverPos);

        //when the player is within range and presses e, give them a quest
        if(Input.GetKeyDown("e") && playerDistance < activationDistance)
        {
            Debug.Log("Quest Accepted: ");
            RecieveQuest();

        }
    }

    void RecieveQuest()
    {
        isFetch = (int) UnityEngine.Random.Range(0f, 2f);
        switch (isFetch)
        {
            case 0:
                Debug.Log("Fetch an item!");
                break;
            case 1:
                Debug.Log("Kill something!");
                break;
            default:
                Debug.Log("I don't have anything for you...");
                break;
        }
    }
}
