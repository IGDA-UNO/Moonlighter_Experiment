using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoom : MonoBehaviour
{
    public enum RoomType {BASE, BOSS, TREASURE}
    
    // public variables
    public Transform p_room;
    public int height;
    public int width;
    public RoomType roomType;
    public bool hasRightExit;
    public bool hasLeftExit;
    public bool hasTopExit;
    public bool hasBottomExit;
    /* 
    [HideInInspector]
    public DungeonRoom rightRoom;
    [HideInInspector]
    public DungeonRoom leftRoom;
    [HideInInspector]
    public DungeonRoom topRoom;
    [HideInInspector]
    public DungeonRoom bottomRoom; 
    */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
