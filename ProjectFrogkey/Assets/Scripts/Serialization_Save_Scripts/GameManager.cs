using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //If a variable is Static, make sure to update this in Start Method or upon Retry the variable will still be whatever it was at GameOver.
    public static bool gameIsOver;

    public GameObject gameOverUI;

    PlayerHealth health;

    PlayerMovement player;

    private GameObject get_player;

    private void Start()
    {
        get_player = GameObject.FindGameObjectWithTag("Player");
        health = get_player.GetComponent<PlayerHealth>();
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

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);

        // SaveData.SavePlayer()
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        // level = data.level
        data.health = health.currentHealth;

        data.position[0] = player.orientation.position.x;
        data.position[1] = player.orientation.position.y;
        data.position[2] = player.orientation.position.z;


        Vector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];



        player.orientation.position = position;

    }
}
