using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DectionTypes
{
    ZBoxFrontDetection, ZDimanondFrontDetection, ZDimaondHalfFrontDetection, ZDimaondThirdFrontDetection, AreaBoxDetection, AreaDimaondDetection, XBoxFrontDetection, XDimanondFrontDetection, XDimaondHalfFrontDetection, XDimaondThirdFrontDetection
}


public class DetectionStatMachine : MonoBehaviour
{

    public DectionTypes DropSelect = new DectionTypes();
    
    public Transform PlayerFroggy;

    public int PlayerWithInDistance = 5;
    protected bool PlaySpotted = false; //boolean keep track if the player was spoted in the dection and when player leaves the reactable dection area

    
    public int StopFollowDistance = 20;

    void Start()
    {
        PlayerFroggy = GameObject.FindGameObjectWithTag("FindPlayer").transform;
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
            PlaySpotted = false;
}

    }
    

    protected void DetectionStateCheck()
    {
        if (DropSelect == DectionTypes.ZBoxFrontDetection)
        {
            ZBoxFront();
        }
        else if (DropSelect == DectionTypes.ZDimanondFrontDetection)
        {
            ZDimanondFront();
        }
        else if (DropSelect == DectionTypes.ZDimaondHalfFrontDetection)
        {
            ZDimaondHalfFront();
        }
        else if (DropSelect == DectionTypes.ZDimaondThirdFrontDetection)
        {
            ZDimaondThirdFront();
        }
        else if (DropSelect == DectionTypes.AreaBoxDetection)
        {
            AreaBox();
        }
        else if (DropSelect == DectionTypes.AreaDimaondDetection)
        {
            AreaDimaond();
        }
        else if (DropSelect == DectionTypes.XBoxFrontDetection)
        {
            XBoxFront();
        }
        else if (DropSelect == DectionTypes.XDimanondFrontDetection)
        {
            XDimanondFront();
        }
        else if (DropSelect == DectionTypes.XDimaondHalfFrontDetection)
        {
            XDimaondHalfFront();
        }
        else if (DropSelect == DectionTypes.XDimaondThirdFrontDetection)
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
        }

    }

}