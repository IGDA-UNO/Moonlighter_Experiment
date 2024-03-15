using System.Collections;
using System.Collections.Generic;
using SuperTiled2Unity.Editor;
using UnityEngine;

public enum QuestType{Fetch, Kill};
public enum QuestStatus {Active, Pending, Complete};

/*
TODO
    Instantiation of target GameObject in the correct Scene.

    Implement more sophisticated reward and naming logic.
    ...Atm, placeholder values are used.
    ...Reward should be based on some difficulty factor. Names can be simple like "Kill a Spitter."

    Requires completion conditions.
*/

// Represents the various data held within a Quest for a player.
public class Quest
{
    // Fields
    public GameObject target;
    [SerializeField]private string questName;
    [SerializeField]private QuestType type;
    [SerializeField]private GameObject targets;
    [SerializeField]private int reward;
    [SerializeField]private QuestStatus status;

    public Quest(QuestType type, QuestStatus status){
        this.type = type;
        this.status = status;
        this.questName = "Placeholder";
        this.reward = 100;

        // Warning: the following code is awful and may leave the viewer traumatized...
        /* 
        A target for the quest will be acquired based on if it should be an item or a monster.
        TODO: Get a reference to the length of arrays in QuestTarget to be used as an upper-bound for Random.
        */
        this.targets = GameObject.Find("QuestTarget");
        if(type == QuestType.Fetch)
            target = targets.GetComponent<QuestTarget>().collectables[Random.Range(0, 1)];
        else
            target = targets.GetComponent<QuestTarget>().enemies[Random.Range(0, 3)];;

        Debug.Log("Type: " + type.ToString() + " Status: " + status.ToString()
                    + " Name: " + questName + " Target: " + target.name);
    }

    public QuestType GetQuestType(){
        return this.type;
    }

    public QuestStatus GetQuestStatus(){
        return this.status;
    }

    public int GetReward(){
        return this.reward;
    }

    public string GetQuestName(){
        return this.questName;
    }
}
