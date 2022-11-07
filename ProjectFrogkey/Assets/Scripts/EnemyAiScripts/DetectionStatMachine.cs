using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DectionTypes
{
    ZBoxFrontD, ZDimanondFrontD, ZDimaondHalfFrontD, ZDimaondThirdFrontD, AreaBoxD, AreaDimaondD, XBoxFrontD, XDimanondFrontD, XDimaondHalfFrontD, XDimaondThirdFrontD
}


public class DetectionStatMachine : MonoBehaviour
{

    public DectionTypes DropSelect = new DectionTypes();

    //DectionTypes Selected = DectionTypes.Diamond;
    //DectionTypes current_state; // = DectionTypes.Diamond;

    private float speed = 1.0f;//
    private float Speeding = 4.0f;//

    public Transform PlayerFroggy;

    public int PlayerWithInDistance = 5;
    private bool PlaySpotted = false;

    private bool EnemyStopFollow = false;
    public int StopFollowDistance = 20;

    void Start()
    {
        PlayerFroggy = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        StateCheck();
        if (PlayerFroggy != null && PlaySpotted == true && EnemyStopFollow == false)
        {
            LookAtPlayer();
            MoveForward();

            StopFollowing();
        }
    }
    
    void LookAtPlayer()//
    {
        Vector3 director = PlayerFroggy.position - transform.position; //This finds the distance from were it is to were it want to go
        Quaternion rotator = Quaternion.LookRotation(director); // This uses the director to look to the direction its going
        transform.rotation = Quaternion.Lerp(transform.rotation, rotator, speed * Time.deltaTime); //this rotate it 
    }

    void MoveForward()//
    {
        this.transform.Translate(0, 0, Speeding * Time.deltaTime);
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
    

    void StateCheck()
    {
        if (DropSelect == DectionTypes.ZBoxFrontD)
        {
            ZBoxFront();
        }
        else if (DropSelect == DectionTypes.ZDimanondFrontD)
        {
            ZDimanondFront();
        }
        else if (DropSelect == DectionTypes.ZDimaondHalfFrontD)
        {
            ZDimaondHalfFront();
        }
        else if (DropSelect == DectionTypes.ZDimaondThirdFrontD)
        {
            ZDimaondThirdFront();
        }
        else if (DropSelect == DectionTypes.AreaBoxD)
        {
            AreaBox();
        }
        else if (DropSelect == DectionTypes.AreaDimaondD)
        {
            AreaDimaond();
        }
        else if (DropSelect == DectionTypes.XBoxFrontD)
        {
            XBoxFront();
        }
        else if (DropSelect == DectionTypes.XDimanondFrontD)
        {
            XDimanondFront();
        }
        else if (DropSelect == DectionTypes.XDimaondHalfFrontD)
        {
            XDimaondHalfFront();
        }
        else if (DropSelect == DectionTypes.XDimaondThirdFrontD)
        {
            XDimaondThirdFront();
        }
    }

    void ZBoxFront() //box radius
    {
        if (PlayerFroggy.transform.position.z > this.transform.position.z &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * 2)) &&
            PlayerFroggy.transform.position.x > (this.transform.position.x - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + PlayerWithInDistance))
        {
            PlaySpotted = true;
            EnemyStopFollow = false;
        }
    }


    void ZDimanondFront() // Dimanond Detction Radius
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

    void ZDimaondHalfFront() // Dimanond with one cormer a Half of the size Detction Radius
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

    void ZDimaondThirdFront() // Dimanond with one cormer a third of the size Detction Radius
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

    void AreaBox() //Box detect that surounds the enmey
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

    void AreaDimaond() //diamond detect that surounds the enmey
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


    void XBoxFront() //box radius
    {
        if (PlayerFroggy.transform.position.x > this.transform.position.x &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + (PlayerWithInDistance * 2)) &&
            PlayerFroggy.transform.position.z > (this.transform.position.z - PlayerWithInDistance) &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + PlayerWithInDistance))
        {
            PlaySpotted = true;
            EnemyStopFollow = false;
        }
    }

    void XDimanondFront() // Dimanond Detction Radius
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
            EnemyStopFollow = false;
        }
    }

    void XDimaondHalfFront() // Dimanond with one cormer a Half of the size Detction Radius
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
            EnemyStopFollow = false;
        }


    }

    void XDimaondThirdFront() // Dimanond with one cormer a third of the size Detction Radius
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
            EnemyStopFollow = false;
        }

    }

}