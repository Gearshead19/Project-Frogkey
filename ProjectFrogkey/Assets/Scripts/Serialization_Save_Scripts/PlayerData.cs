using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]

public class PlayerData
{
    public string playerName;
    public int currency;
    public float[] position;
    public int level;
    public int health;

    //Using Player Class
    public PlayerData(PlayerMovement playerPos, PlayerHealth playerHealth)
        {
        //level = player.currentHealth;
       // health = playerHealth.currentHealth;

        position = new float[3];

        position[0] = playerPos.orientation.position.x;
        position[1] = playerPos.orientation.position.y;
        position[2] = playerPos.orientation.position.z;
        // positions are replaced with player's current xyz position.
    }

  
    }

