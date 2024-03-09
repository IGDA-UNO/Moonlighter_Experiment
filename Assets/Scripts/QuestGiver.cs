using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestGiver : MonoBehaviour
{
    [SerializeField]private Vector3 playerPos;
    [SerializeField]private Vector3 questGiverPos;
    [SerializeField]private float playerDistance;
    private bool isInRange;
    private readonly float playerActivationDistance = 10;
    public QuestManager questManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindWithTag("Player").transform.position;
        questGiverPos = GameObject.Find("QuestGiver").transform.position;
        playerDistance = Vector3.Distance(playerPos, questGiverPos);

        if(Input.GetKeyDown("e") && playerDistance < playerActivationDistance)
        {
            Debug.Log("Quest Accepted: ");
            RecieveQuest();
            questManager.ShowNewQuest();
        }
    }

    void RecieveQuest()
    {
        int isFetch = (int) UnityEngine.Random.Range(0f, 2f);
        switch (isFetch)
        {
            case 0:
                questManager.AddQuest(new Quest(Quest.QuestType.Fetch, Quest.QuestStatus.Pending));
                break;
            case 1:
                questManager.AddQuest(new Quest(Quest.QuestType.Kill, Quest.QuestStatus.Pending));
                break;
            default:
                Debug.Log("I don't have anything for you...");
                break;
        }
    }
}
