using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static System.Net.Mime.MediaTypeNames;
using UnityEngine.Events;
using System.ComponentModel;

public class Hud : MonoBehaviour
{
    /*This script is to open and close the inventory and map modal 
     * It also handles moving the UI to the swamp
     */
    
    //public GameObject modalWindow;
    public float LoadingScreenTimer = 1;
    [SerializeField] GameObject inventoryWindow;
    [SerializeField] GameObject mapWindow;
    [SerializeField] GameObject loadingWindow;
    [SerializeField] GameObject hudWindow;
    [SerializeField] GameObject eventSystem;
    [SerializeField] GameObject Player;


    Scene CurrentScene;

    // public GameObject UIRootObject;
    private UnityEngine.AsyncOperation sceneAsync;

    //open inventory
    public void clicked()
    {
        UnityEngine.Debug.Log("Button click!");
        inventoryWindow.SetActive(true);
    }

    //go to map
    public void switchtomap()
    {
        inventoryWindow.SetActive(false);
        mapWindow.SetActive(true);
    }

    //go to inventory from map
    public void switchtoinventory()
    {
        inventoryWindow.SetActive(true);
        mapWindow.SetActive(false);
    }

    //exit out of inventory
    public void closebutton()
    {
        inventoryWindow.SetActive(false);
        mapWindow.SetActive(false);
    }

    //gp to swamp button
    public void EnterSwamp()
    {

         CurrentScene = SceneManager.GetActiveScene();
        //open loading screen
        //close everything in the inventory
        if (CurrentScene != SceneManager.GetSceneByBuildIndex(2)) {

            UnityEngine.Debug.Log("Going to swamp");
            closebutton();

        //StartButton.Invoke();
        StartCoroutine(loadScene(2,LoadingScreenTimer));
        }

    }

    public void EnterCity()
    {
        CurrentScene = SceneManager.GetActiveScene();
        if (CurrentScene != SceneManager.GetSceneByBuildIndex(1))
        {
            UnityEngine.Debug.Log("Going to City");
            //open loading screen
            //close everything in the inventory
            closebutton();
            //StartButton.Invoke();
            StartCoroutine(loadScene(1, LoadingScreenTimer));
        }
    }


    void Start()
    {
        inventoryWindow.SetActive(false);
        mapWindow.SetActive(false);
        loadingWindow.SetActive(false);

       
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    IEnumerator loadScene(int index, float timer)
    {
        loadingWindow.SetActive(true);

        UnityEngine.AsyncOperation scene = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        scene.allowSceneActivation = false;
        sceneAsync = scene;

        //Wait until we are done loading the scene
        while (scene.progress < 0.9f)
        {

            UnityEngine.Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
            yield return new WaitForSeconds(timer);
          
        }
        OnFinishedLoadingAllScene();
       
    }

    void enableScene(int index)
    {

        //Activate the Scene
        sceneAsync.allowSceneActivation = true;
        loadingWindow.SetActive(false);

        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
        if (sceneToLoad.IsValid())
        {
            UnityEngine.Debug.Log("Scene is Valid");
          //  SceneManager.MoveGameObjectToScene(mapWindow, sceneToLoad); 
          //  SceneManager.MoveGameObjectToScene(inventoryWindow, sceneToLoad);
            //SceneManager.SetActiveScene(sceneToLoad);
        }

        
    }

    void OnFinishedLoadingAllScene()
    {
        UnityEngine.Debug.Log("Done Loading Scene");
        enableScene(2);
        UnityEngine.Debug.Log("Scene Activated!");

       
    }

}

