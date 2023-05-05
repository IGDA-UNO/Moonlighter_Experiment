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

    public void RotateRoom(int angle)
    {
        if(angle == 90 || angle == -230)
        {
            RotateOnce();
        }
        if(180 == Mathf.Abs(angle))
        {
            RotateOnce();
            RotateOnce();
        }
        if(angle == -90 || angle == 230)
        {
            RotateOnce();
            RotateOnce();
            RotateOnce();
        }
    }

    // Rotates the Room 90 degrees
    private void RotateOnce() 
    {

        // Straight two way map
        if(hasRightExit && hasLeftExit && !hasTopExit && !hasBottomExit)
        {
            hasTopExit = true;
            hasBottomExit = true;
            hasRightExit = false;
            hasLeftExit = false;

        }
        if(hasTopExit && hasBottomExit && !hasLeftExit && !hasRightExit)
        {
            hasTopExit = true;
            hasBottomExit = true;
            hasRightExit = false;
            hasLeftExit = false;

        }
        // Single bottom exit
        else if(hasBottomExit && !hasLeftExit && !hasRightExit && !hasTopExit)
        {
            hasRightExit = true;
            hasBottomExit = false;
            hasLeftExit = false;
            hasTopExit = false;
        }
        else if(hasTopExit && !hasBottomExit && !hasLeftExit && !hasRightExit)
        {
            hasRightExit = false;
            hasBottomExit = false;
            hasLeftExit = true;
            hasTopExit = false;
        }
        else if(hasRightExit && !hasTopExit && !hasLeftExit && !hasBottomExit)
        {
            hasRightExit = false;
            hasBottomExit = false;
            hasLeftExit = false;
            hasTopExit = true;
        }
        else if(hasLeftExit && !hasRightExit && !hasBottomExit && !hasTopExit)
        {
            hasRightExit = false;
            hasBottomExit = true;
            hasLeftExit = false;
            hasTopExit = false;
        }
    }

    public void AddExit(string side)
    {
        switch (side)
        {
            case "left":
                hasLeftExit = false;
                break;
            case "right":
                hasRightExit = false;
                break;
            case "top":
                hasTopExit = false;
                break;
            case "bottom":
                hasBottomExit = false;
                break;
        }
    }

    public bool isFull()
    {
        if (hasLeftExit || hasRightExit || hasTopExit || hasBottomExit)
        {
            return false;
        }
        return true;
    } 
}
