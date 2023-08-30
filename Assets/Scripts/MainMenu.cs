using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static System.Net.Mime.MediaTypeNames;
using UnityEngine.Events;


public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject MainMenuUI;
    [SerializeField] GameObject MainMenuMusic;

    public UnityEvent StartButton;

    public void PlayGame()
    {
        StartButton.Invoke();
        SceneManager.LoadScene("Lenaoria & Christinas scene");
        SceneManager.LoadScene("CityScene", LoadSceneMode.Additive);
        MainMenuUI.SetActive(false);

        //stop main menu music
    
        Destroy(MainMenuMusic);


        //MainMenuMusic = MainMenuCamera.GetComponent<AudioSource>();
        //MainMenuMusic = MainMenuCamera.GetComponent<AudioSource>();


        //  MainMenuCamera.Mute();
        //
        //, LoadSceneMode.Additive
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
