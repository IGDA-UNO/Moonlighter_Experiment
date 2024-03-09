using System.Collections;
using System.Collections.Generic;
using SuperTiled2Unity.Editor;
using UnityEngine;

public class Quest
{
    //Enums that help determine quest type and quest status
    public enum QuestType{Fetch, Kill};
    public enum QuestStatus {Active, Pending, Complete};

    //Class variables
    private string questName;
    private QuestType type;
    private QuestStatus status;
    private int reward;
    // Also need a Target variable that will refer to the target of the quest

    public Quest(QuestType type, QuestStatus status){
        this.type = type;
        this.status = status;
        this.questName = "Placeholder";
        // Set reward to some value ideally related to the "difficulty" of the quest
        // Set target based on quest type
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
