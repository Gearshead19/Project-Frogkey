using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static PauseMenu instance;

    private void Awake()
    {
        instance = this;
    }


    public GameObject ui;

    public SceneFader sceneFader;

    public string menuSceneName = "TitleScreen";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;

            //Muffles music when paused
            AkSoundEngine.SetState("GamePause", "IsPaused");
        }
        else
        {
            Time.timeScale = 1f;

            //Un-muffles music when un-paused
            AkSoundEngine.SetState("GamePause", "NotPaused");
        }


    }

    //Temporary Pause Button

    private void OnPause()
    {
        Toggle();
    }
    public void Continue()
    {
        Toggle();
        if (ui.activeSelf == false)
        {
            Debug.Log("UI is gone");
        }
        else
        {
            Debug.Log("Something's wrong.");
        }
    }
    public void Retry ()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
       
    }
    public void Menu ()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
    public void Quit()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
