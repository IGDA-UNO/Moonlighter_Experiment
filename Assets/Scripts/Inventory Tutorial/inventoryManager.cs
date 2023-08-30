
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    /* Add item in inventory(list)
     * Play animation of item being collected
     * Count how many objects the player has
     * Checking if inventory is full, and rejecting 
     */

    //https://www.youtube.com/watch?v=Y7pp2gzCzUI&ab_channel=DaniKrossing
    //https://www.youtube.com/watch?v=dtv7mjj_iog&ab_channel=Tarodev

    [SerializeField] Collectable collectable;

  //  public GameObject slotPrefab;

    //list called Inventory    == inventory slots



    public List<Collectable> Inventory = new List<Collectable>();

    // Start is called before the first frame update
    void Start()
    {
       // isItCollected = collectable.isCollected;
    }

    // Update is called once per frame
    void Update()
    {
        // public List<Collectable> Inventory = new List<Collectable>();
}

    //add collectable to inventory 
   public void addToInventory(Collectable collectable)

    {       //add the collected item the player just touched to the inventory list
             Inventory.Add(collectable);
           UnityEngine.Debug.Log("Item added");

        int counter = 0;
        //print the full LIST 
         foreach (Collectable c in Inventory) {
            UnityEngine.Debug.Log(c);
            counter++;
            UnityEngine.Debug.Log(counter);
        }

        UnityEngine.Debug.Log(collectable);
    }
}
