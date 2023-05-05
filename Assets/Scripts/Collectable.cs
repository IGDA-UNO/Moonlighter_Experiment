using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ObjectAdded : UnityEvent<Collectable> { }

public class Collectable : MonoBehaviour
{
    /*
     * Collectable potion
     * To-DO
     * find way to reference game object
     * Make a method to store object when player touches it
     *
     **/
    public bool isCollected = false;
    public ObjectAdded hasBeenPickedUp;

    // Start is called before the first frame update
    void Start()
    {
       // hasBeenPickedUp = new ObjectAdded();
    }
    // Update is called once per frame
    void Update()
    {

    }

    //when touching the item 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {  
            gameObject.SetActive(false); 
            isCollected = true;
            hasBeenPickedUp.Invoke(this);

        }
    }

}
