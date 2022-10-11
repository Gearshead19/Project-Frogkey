using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyLook : MonoBehaviour
{
    public Transform PlayerFroggy;
    private float speed = 1.0f;

    void Start()
    {
        PlayerFroggy = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (PlayerFroggy != null)
        {
            LookAtPlayer();
        }
    }

    void LookAtPlayer()
    {
        Vector3 director = PlayerFroggy.position - transform.position; //This finds the distance from were it is to were it want to go
        Quaternion rotator = Quaternion.LookRotation(director); // This uses the director to look to the direction its going
        transform.rotation = Quaternion.Lerp(transform.rotation, rotator, speed * Time.deltaTime); //this rotate it 
    }
}
