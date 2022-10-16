using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyLook : MonoBehaviour
{
    public Transform PlayerFroggy;
    private float speed = 1.0f;
    private float Speeding = 4.0f;

    public int PlayerWithInDistance = 5;
    private bool PlaySpotted = false;

    void Start()
    {
        PlayerFroggy = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        SeekPlayerBasic();

        if (PlayerFroggy != null && PlaySpotted == true)
        {                      
            LookAtPlayer();
            MoveForward();
        }
    }

    void SeekPlayerBasic() //box radius
    {
        if(PlayerFroggy.transform.position.z > this.transform.position.z && 
            PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance*2)) &&
            PlayerFroggy.transform.position.x > (this.transform.position.x - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + PlayerWithInDistance))
        {
            PlaySpotted = true;
        }
    }

    void LookAtPlayer()
    {
        Vector3 director = PlayerFroggy.position - transform.position; //This finds the distance from were it is to were it want to go
        Quaternion rotator = Quaternion.LookRotation(director); // This uses the director to look to the direction its going
        transform.rotation = Quaternion.Lerp(transform.rotation, rotator, speed * Time.deltaTime); //this rotate it 
    }

    void MoveForward()
    {
        this.transform.Translate(0, 0, Speeding * Time.deltaTime);
    }
}
