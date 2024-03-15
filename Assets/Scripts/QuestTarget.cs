using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
TODO
    Find a better way of obtaining all possible enemy/collectable types.
    ...The current method is gonna be a little annoying to keep updating when we add more enemies/items.

    Add a "weight" system to each target. This will determine how difficult a respective target will be to
    ...retrieve or to defeat.
*/

// Just contains references to enemy and collectable prefabs.
// Problematic when adding new types as this will need to be updated within the editor.

/*
TODO
    Gather the prefabs required for whatever data structure is implemented in the Start() function.
*/
public class QuestTarget : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] collectables;
}
