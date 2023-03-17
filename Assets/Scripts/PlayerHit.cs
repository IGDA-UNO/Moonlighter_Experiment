using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHit : MonoBehaviour
{
    /* This manages the player's weapon. 
    * You might consider this the player's weapon's class.
    * If you examine the animator you can find the shovel hit
    * thing, and that is what is actually damaging other things.
    *
    * You might want to rename ShovelHitboxNorth eventually,
    * or make other WeaponHitboxNorth etc.
    \*/



    public String weaponName;
    public int damage;
    public int attackCooldown;
    //needs graphics data/hitbox data to manage different enemies?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        //When the weapon hitbox is active, it detects the collision here.
        //This is where we may want to manage the damage interaction.

        if(other.gameObject.CompareTag("Breakable")){

            Debug.Log("HT!");
            Debug.Log("You just attacked " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }

    int getDamage(){
        return this.damage;
    }

    String getName(){
        return this.weaponName;
    }

    int getCooldown(){
        return this.attackCooldown;
    }
}
