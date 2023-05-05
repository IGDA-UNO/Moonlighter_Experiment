using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static System.Net.Mime.MediaTypeNames;
using UnityEngine.Events;


public class MainMenu : MonoBehaviour
{

     public UnityEvent StartButton;

    public void PlayGame()
    {
        StartButton.Invoke();
        SceneManager.LoadScene("MAPscene");
        SceneManager.LoadScene("Lenaoria & Christinas scene", LoadSceneMode.Additive);
      
        //, LoadSceneMode.Additive
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
