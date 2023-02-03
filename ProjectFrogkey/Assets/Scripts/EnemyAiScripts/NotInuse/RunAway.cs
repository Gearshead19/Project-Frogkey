using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    public Transform PlayerFroggy;
    public float speed = 5.0f;

    public int PlayerWithInDistance = 5;
    private bool PlaySpotted = false;

    private bool EnemyStopFollow = false; //runawasystpo
    public int StopFollowDistance = 20; //runawydistance
    void Start()
    {
        PlayerFroggy = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        AreaDetectPlayerBox();
        if (PlayerFroggy != null && PlaySpotted == true && EnemyStopFollow == false)
        {
            RunAwayFrom();

            StopFollowing();
        }
    }

    private void RunAwayFrom()
    {
        if(PlayerFroggy.transform.position.x > this.transform.position.x)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (PlayerFroggy.transform.position.x < this.transform.position.x)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (PlayerFroggy.transform.position.z > this.transform.position.z)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        if (PlayerFroggy.transform.position.z < this.transform.position.z)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    void StopFollowing()
    {
        if (PlayerFroggy.transform.position.z < (this.transform.position.z - StopFollowDistance) ||
            PlayerFroggy.transform.position.z > (this.transform.position.z + StopFollowDistance) ||
            PlayerFroggy.transform.position.x < (this.transform.position.x - StopFollowDistance) ||
            PlayerFroggy.transform.position.x > (this.transform.position.x + StopFollowDistance))
        {
            EnemyStopFollow = true;
        }

    }

    void AreaDetectPlayerBox() //Box detect that surounds the enmey
    {
        if (PlayerFroggy.transform.position.x > this.transform.position.x - PlayerWithInDistance &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + PlayerWithInDistance) &&
            PlayerFroggy.transform.position.z > (this.transform.position.z - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + PlayerWithInDistance))
        {
            PlaySpotted = true;
            EnemyStopFollow = false;
        }
    }
}
