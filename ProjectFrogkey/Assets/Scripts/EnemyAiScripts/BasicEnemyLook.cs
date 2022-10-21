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

    private bool EnemyStopFollow = false;
    public int StopFollowDistance = 20;

    public GameObject[] Markering;


    void Start()
    {
        PlayerFroggy = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // MarkerRadius();

        //SeekPlayerBasic();
        //SeekPlyaerDimaond();
        //SeekPlyaerDimaondWithThird();
        AreaDetectPlayerDimaond();
        if (PlayerFroggy != null && PlaySpotted == true && EnemyStopFollow == false)
        {                      
            LookAtPlayer();
            MoveForward();

            StopFollowing();
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

    void SeekPlayerBasic() //box radius
    {
        if(PlayerFroggy.transform.position.z > this.transform.position.z && 
            PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance*2)) &&
            PlayerFroggy.transform.position.x > (this.transform.position.x - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + PlayerWithInDistance))
        {
            PlaySpotted = true;
            EnemyStopFollow = false;
        }
    }

    void SeekPlyaerDimaond() // Dimanond Detction Radius
    {
        if (PlayerFroggy.transform.position.z > this.transform.position.z &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * 2)) &&
            PlayerFroggy.transform.position.x > (this.transform.position.x - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + PlayerWithInDistance) &&
            ((PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * 1.5)) && PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * 1.5)) && PlayerFroggy.transform.position.x < (this.transform.position.x - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.x < (this.transform.position.x - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * .5))) != true)
            )
        {
            PlaySpotted = true;
            EnemyStopFollow = false;
        }
    }

    void SeekPlyaerDimaondWithHalf() // Dimanond with one cormer a Half of the size Detction Radius
    {
        if (PlayerFroggy.transform.position.z > this.transform.position.z &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * 1.5)) &&
            PlayerFroggy.transform.position.x > (this.transform.position.x - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + PlayerWithInDistance) &&
            ((PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * 1.25)) && PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * 1.25)) && PlayerFroggy.transform.position.x < (this.transform.position.x - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.x < (this.transform.position.x - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * .5))) != true)
            )
        {
            PlaySpotted = true;
            EnemyStopFollow = false;
        }


    }

    void SeekPlyaerDimaondWithThird() // Dimanond with one cormer a third of the size Detction Radius
    {
        if (PlayerFroggy.transform.position.z > this.transform.position.z &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * 1.25)) &&
            PlayerFroggy.transform.position.x > (this.transform.position.x - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + PlayerWithInDistance) &&
            ((PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * 1.125)) && PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * 1.125)) && PlayerFroggy.transform.position.x < (this.transform.position.x - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.x < (this.transform.position.x - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.x > (this.transform.position.x + (PlayerWithInDistance * .5))) != true)
            )
        {
            PlaySpotted = true;
            EnemyStopFollow = false;
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

    void AreaDetectPlayerDimaond() //diamond detect that surounds the enmey
    {
        if (PlayerFroggy.transform.position.x > this.transform.position.x - PlayerWithInDistance &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + PlayerWithInDistance) &&
            PlayerFroggy.transform.position.z > (this.transform.position.z - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + PlayerWithInDistance) &&
            ((PlayerFroggy.transform.position.x > (this.transform.position.x - (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.x > (this.transform.position.x - (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.z < (this.transform.position.z - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.z < (this.transform.position.z - (PlayerWithInDistance * .5))) != true) &&
            ((PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * .5)) && PlayerFroggy.transform.position.z > (this.transform.position.z + (PlayerWithInDistance * .5))) != true)
            )
        {
            PlaySpotted = true;
            EnemyStopFollow = false;
        }
    }

    void MarkerRadius()
    {
        Markering[0].transform.position = new Vector3(this.transform.position.x + PlayerWithInDistance, this.transform.position.y, this.transform.position.z + PlayerWithInDistance);
        Markering[1].transform.position = new Vector3(this.transform.position.x - PlayerWithInDistance, this.transform.position.y, this.transform.position.z + PlayerWithInDistance);
        Markering[2].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + ((PlayerWithInDistance / 4) + PlayerWithInDistance));
        Markering[3].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
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
