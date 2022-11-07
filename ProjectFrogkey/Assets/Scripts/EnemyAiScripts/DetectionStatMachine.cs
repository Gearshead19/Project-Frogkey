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

    public Transform PlayerFroggy;

    public int PlayerWithInDistance = 5;
    protected bool PlaySpotted = false;

    protected bool EnemyStopFollow = false;
    public int StopFollowDistance = 20;

    void Start()
    {
        PlayerFroggy = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        
    }


    protected void StopFollowing()
    {
        if (PlayerFroggy.transform.position.z < (this.transform.position.z - StopFollowDistance) ||
            PlayerFroggy.transform.position.z > (this.transform.position.z + StopFollowDistance) ||
            PlayerFroggy.transform.position.x < (this.transform.position.x - StopFollowDistance) ||
            PlayerFroggy.transform.position.x > (this.transform.position.x + StopFollowDistance))
        {
            EnemyStopFollow = true;
        }

    }
    

    protected void DetectionStateCheck()
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