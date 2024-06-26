using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SuperTiled2Unity;
using UnityEngine;

// Handles adding, removing, reading, and creating Quests.
/*
*/
public class QuestManager : MonoBehaviour
{
    private List<Quest> quests;

    // Start is called before the first frame update
    void Start()
    {
        quests = new List<Quest>();
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies){
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.enemyDies.AddListener(enemyDeathListener);
        }
    }

    private void enemyDeathListener(string enemy){
        Debug.Log(enemy + "has died!");
    }

    public void AddQuest(Quest newQuest){
        quests.Add(newQuest);
    }

    public void RemoveQuest(Quest questToRemove){
        quests.Remove(questToRemove);
    }

    public void ShowQuestLog(){
        if(quests.IsEmpty()){
            Debug.Log("You have no quests...");
            return;
        }
        Debug.Log("QUEST LOG\n");
        for(int i=0; i<quests.Count; i++){
            Quest current = quests[i];
            Debug.Log("------------------------------------------------------\n");
            Debug.Log("Quest #" + (i+1) + ": "+ current.GetQuestName() + "\n");
            Debug.Log("Reward: " + current.GetReward() + "\tStatus: " + current.GetQuestStatus()
                    + "\tType: " + current.GetQuestType() + "\n");
            Debug.Log("------------------------------------------------------\n");
        }
    }

    public void ShowNewQuest(){
        Quest newQuest = quests[^1];
        Debug.Log("New Quest: " + newQuest.GetQuestName());
    }
}
