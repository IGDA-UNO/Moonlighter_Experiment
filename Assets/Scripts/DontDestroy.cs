using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    
   public string objectID;

    private void Awake()
    {
        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();


    }

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < UnityEngine.Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            

            if(UnityEngine.Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if (UnityEngine.Object.FindObjectsOfType<DontDestroy>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }

            }
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
