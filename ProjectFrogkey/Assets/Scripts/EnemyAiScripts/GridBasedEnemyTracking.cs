using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedEnemyTracking : MonoBehaviour
{
    public GameObject FroggyPlayer;

    private float Speed = 2.0f;
    private float Xing;
    private float Zing;
    bool PostiveX;
    bool PostiveY;

    void Start()
    {
        FroggyPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    //This is a graph system, think of it as the x and y charts in gemometry class

    void FixedUpdate()
    {
        Xing = FroggyPlayer.transform.position.x;
        Zing = FroggyPlayer.transform.position.z;

        PostiveX = FroggyPlayer.transform.position.x <= 0;
        PostiveY = FroggyPlayer.transform.position.z <= 0;

        if (Xing > transform.position.x + 1)
        {
            if (Zing > transform.position.z + 1)
            {
                transform.Translate(Speed * Time.deltaTime, 0, Speed * Time.deltaTime);
            }
            else if (Zing < transform.position.z - 1)
            {
                transform.Translate(Speed * Time.deltaTime, 0, -Speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Speed * Time.deltaTime, 0, 0);
            }
        }
        else if (Xing < transform.position.x - 1)
        {
            if (Zing > transform.position.z + 1)
            {
                transform.Translate(-Speed * Time.deltaTime, 0, Speed * Time.deltaTime);
            }
            else if (Zing < transform.position.z - 1)
            {
                transform.Translate(-Speed * Time.deltaTime, 0, -Speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Speed * Time.deltaTime, 0, 0);
            }

        }
        else if (Zing > transform.position.z + 1)
        {
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
        else if (Zing < transform.position.z - 1)
        {
            transform.Translate(0, 0, -Speed * Time.deltaTime);
        }

    }

}
