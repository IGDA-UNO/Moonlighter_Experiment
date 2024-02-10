
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject slotPrefab;
    public Sprite collectableImage;
    

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
            UnityEngine.Debug.Log("Counter of items:"+counter);
            
        }

        UnityEngine.Debug.Log(collectable);
        DisplayInventory(collectable);
    }

    public void DisplayInventory(Collectable theCollectable){
    
    collectableImage = theCollectable.GetComponent<SpriteRenderer>().sprite;
    slotPrefab.GetComponent<Image>().sprite = collectableImage;

      
        //get a reference to the slot image component
        //get a reference to the image of the collectable
        // set the slot image = to the collectable image

   }
}
