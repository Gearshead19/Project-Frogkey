using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedEnemyTracking : MonoBehaviour
{
    public GameObject FroggyPlayer;


    public Transform PlayerFroggy;
    public int PlayerWithInDistance = 5;
    private bool PlaySpotted = false;
    public GameObject[] Markering;

    private bool EnemyStopFollow = false;
    public int StopFollowDistance = 20;

    private float Speed = 2.0f;
    private float Xing;
    private float Zing;
    bool PostiveX;
    bool PostiveY;

    void Start()
    {
        FroggyPlayer = GameObject.FindGameObjectWithTag("Player");
        PlayerFroggy = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        SeekPlyaerDimaondWithThird();
        //MarkerRadius();
    }
    //This is a graph system, think of it as the x and y charts in gemometry class

    void FixedUpdate()
    {
        if (PlaySpotted == true)
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

    void StopFollowing()
    {
        if (PlayerFroggy.transform.position.z < (this.transform.position.z - StopFollowDistance) ||
            PlayerFroggy.transform.position.z > (this.transform.position.z + StopFollowDistance) ||
            PlayerFroggy.transform.position.x < (this.transform.position.x - StopFollowDistance) ||
            PlayerFroggy.transform.position.x > (this.transform.position.x + StopFollowDistance))
        {
            EnemyStopFollow = true;
            Debug.Log(EnemyStopFollow);
        }

    }

    void SeekPlayerBasic() //box radius
    {
        if (PlayerFroggy.transform.position.x > this.transform.position.x &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * 2)) &&
            PlayerFroggy.transform.position.z > (this.transform.position.z - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + PlayerWithInDistance))
        {
            PlaySpotted = true;
        }
    }

    void SeekPlyaerDimaond() // Dimanond Detction Radius
    {
        if (PlayerFroggy.transform.position.x > this.transform.position.x &&
           PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * 2)) &&
           PlayerFroggy.transform.position.z > (this.transform.position.z - PlayerWithInDistance) &&
           PlayerFroggy.transform.position.z < (this.transform.position.z + PlayerWithInDistance) &&
           ((PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * 1.5)) && PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * .5))) != true) &&
           ((PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * 1.5)) && PlayerFroggy.transform.position.z < (this.transform.position.z - (PlayerWithInDistance * .5))) != true) &&
           ((PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.z < (this.transform.position.z - (PlayerWithInDistance * .5))) != true) &&
           ((PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * .5))) != true)
           )
        {
            PlaySpotted = true;
        }
    }

    void SeekPlyaerDimaondWithHalf() // Dimanond with one cormer a Half of the size Detction Radius
    {
        if (PlayerFroggy.transform.position.x > this.transform.position.x &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * 1.5)) &&
            PlayerFroggy.transform.position.z > (this.transform.position.z - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + PlayerWithInDistance) &&
            ((PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * 1.25)) && PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * 1.25)) && PlayerFroggy.transform.position.z < (this.transform.position.z - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.z < (this.transform.position.z - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * .5))) != true)
            )
        {
            PlaySpotted = true;
        }


    }

    void SeekPlyaerDimaondWithThird() // Dimanond with one cormer a third of the size Detction Radius
    {
        if (PlayerFroggy.transform.position.x > this.transform.position.x &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * 1.25)) &&
            PlayerFroggy.transform.position.z > (this.transform.position.z - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + PlayerWithInDistance) &&
            ((PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * 1.125)) && PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * 1.125)) && PlayerFroggy.transform.position.z < (this.transform.position.z - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.z < (this.transform.position.z - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * .5))) != true)
            )
        {
            PlaySpotted = true;
        }


    }

    void MarkerRadius()
    {
        Markering[0].transform.position = new Vector3(this.transform.position.z + PlayerWithInDistance, this.transform.position.y, this.transform.position.x + PlayerWithInDistance);
        Markering[1].transform.position = new Vector3(this.transform.position.z - PlayerWithInDistance, this.transform.position.y, this.transform.position.x + PlayerWithInDistance);
        Markering[2].transform.position = new Vector3(this.transform.position.z, this.transform.position.y, this.transform.position.x + ((PlayerWithInDistance / 4) + PlayerWithInDistance));
        Markering[3].transform.position = new Vector3(this.transform.position.z, this.transform.position.y, this.transform.position.x);
    }

}
