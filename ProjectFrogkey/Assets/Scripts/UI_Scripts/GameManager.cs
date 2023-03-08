using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //If a variable is Static, make sure to update this in Start Method or upon Retry the variable will still be whatever it was at GameOver.
    public static bool gameIsOver;

    public GameObject gameOverUI;

    PlayerHealth health; 


    private void Start()
    {
        gameIsOver = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        //Test Game Over Screen with this Key Press
        //if (Input.GetKeyDown("e"))
        //{
        //    EndGame();
        //}


        if (health.currentHealth <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        gameIsOver = true;
        
        gameOverUI.SetActive(true);

    }
}
