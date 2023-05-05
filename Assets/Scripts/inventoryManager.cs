
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
    private List<Collectable> Inventory = new List<Collectable>();

    // Start is called before the first frame update
    void Start()
    {
       // isItCollected = collectable.isCollected;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //add collectable to inventory 
   public void addToInventory(Collectable collectable)
    {
             Inventory.Add(collectable);
           UnityEngine.Debug.Log("Item added");
         foreach (Collectable c in Inventory) {
            UnityEngine.Debug.Log(c);
        }

        UnityEngine.Debug.Log(collectable);
    }
}
