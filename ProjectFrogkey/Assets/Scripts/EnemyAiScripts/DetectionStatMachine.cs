using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DectionTypes
{
    ZBoxFrontDetection, ZDimanondFrontDetection, AreaBoxDetection, AreaDimaondDetection, XBoxFrontDetection, XDimanondFrontDetection,
}


public class DetectionStatMachine : MonoBehaviour
{

    public DectionTypes DropSelect = new DectionTypes();
    
    public Transform PlayerFroggy;

    public int PlayerWithInDistance = 5;
    protected bool PlaySpotted = false; //boolean keep track if the player was spoted in the dection and when player leaves the reactable dection area

    public int length = 2; //distance away from player that caluates the dimensions the diamons

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
        Vector3 Player = PlayerFroggy.transform.position;
        Vector3 Enemy = this.transform.position;

        if (Player.z < (Enemy.z - StopFollowDistance) ||
            Player.z > (Enemy.z + StopFollowDistance) ||
            Player.x < (Enemy.x - StopFollowDistance) ||
            Player.x > (Enemy.x + StopFollowDistance))
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
       
    }

    void ZBoxFront() //box radius
    {

        Vector3 Player = PlayerFroggy.transform.position;
        Vector3 Enemy = this.transform.position;

        if (Player.z > Enemy.z &&
            Player.z < (Enemy.z + (PlayerWithInDistance * length)) &&
            Player.x > (Enemy.x - PlayerWithInDistance) &&
            Player.x < (Enemy.x + PlayerWithInDistance))
        {
            PlaySpotted = true;
        }
    }


    void ZDimanondFront() // Dimanond Detction Radius
    {
        Vector3 Player = PlayerFroggy.transform.position;
        Vector3 Enemy = this.transform.position;
        int miniLength = ((length - 1) / 2) + 1;

        if (Player.z > Enemy.z &&
            Player.z < (Enemy.z + (PlayerWithInDistance * length)) &&
            Player.x > (Enemy.x - PlayerWithInDistance) &&
            Player.x < (Enemy.x + PlayerWithInDistance) &&
            ((Player.z > (Enemy.z + (PlayerWithInDistance * miniLength)) && Player.x > (Enemy.x + (PlayerWithInDistance * .5))) != true) &&
            ((Player.z > (Enemy.z + (PlayerWithInDistance * miniLength)) && Player.x < (Enemy.x - (PlayerWithInDistance * .5))) != true) &&
            ((Player.z < (Enemy.z + (PlayerWithInDistance * .5)) && Player.x < (Enemy.x - (PlayerWithInDistance * .5))) != true) &&
            ((Player.z < (Enemy.z + (PlayerWithInDistance * .5)) && Player.x > (Enemy.x + (PlayerWithInDistance * .5))) != true)
            )
        {
            PlaySpotted = true;
        }
    }

    
    void AreaBox() //Box detect that surounds the enmey
    {
        Vector3 Player = PlayerFroggy.transform.position;
        Vector3 Enemy = this.transform.position;

        if (Player.x > Enemy.x - PlayerWithInDistance &&
            Player.x < (Enemy.x + PlayerWithInDistance) &&
            Player.z > (Enemy.z - PlayerWithInDistance) &&
            Player.z < (Enemy.z + PlayerWithInDistance))
        {
            PlaySpotted = true;
        }
    }

    void AreaDimaond() //diamond detect that surounds the enmey
    {
        Vector3 Player = PlayerFroggy.transform.position;
        Vector3 Enemy = this.transform.position;

        if (Player.x > Enemy.x - PlayerWithInDistance &&
            Player.x < (Enemy.x + PlayerWithInDistance) &&
            Player.z > (Enemy.z - PlayerWithInDistance) &&
            Player.z < (Enemy.z + PlayerWithInDistance) &&
            ((Player.x > (Enemy.x - (PlayerWithInDistance * .5)) && Player.z > (Enemy.z + (PlayerWithInDistance * .5))) != true) &&
            ((Player.x > (Enemy.x - (PlayerWithInDistance * .5)) && Player.z < (Enemy.z - (PlayerWithInDistance * .5))) != true) &&
            ((Player.x < (Enemy.x + (PlayerWithInDistance * .5)) && Player.z < (Enemy.z - (PlayerWithInDistance * .5))) != true) &&
            ((Player.x < (Enemy.x + (PlayerWithInDistance * .5)) && Player.z > (Enemy.z + (PlayerWithInDistance * .5))) != true))
        {
            PlaySpotted = true;
        }
    }


    void XBoxFront() //box radius
    {
        Vector3 Player = PlayerFroggy.transform.position;
        Vector3 Enemy = this.transform.position;

        if (Player.x > Enemy.x &&
            Player.x < (Enemy.x + (PlayerWithInDistance * 2)) &&
            Player.z > (Enemy.z - PlayerWithInDistance) &&
            Player.z < (Enemy.z + PlayerWithInDistance))
        {
            PlaySpotted = true;
        }
    }

    void XDimanondFront() // Dimanond Detction Radius
    {
        Vector3 Player = PlayerFroggy.transform.position;
        Vector3 Enemy = this.transform.position;
        int miniLength = ((length - 1) / 2) + 1;

        if (Player.x > Enemy.x &&
           Player.x < (Enemy.x + (PlayerWithInDistance * length)) &&
           Player.z > (Enemy.z - PlayerWithInDistance) &&
           Player.z < (Enemy.z + PlayerWithInDistance) &&
           ((Player.x > (Enemy.x + (PlayerWithInDistance * miniLength)) && Player.z > (Enemy.z + (PlayerWithInDistance * .5))) != true) &&
           ((Player.x > (Enemy.x + (PlayerWithInDistance * miniLength)) && Player.z < (Enemy.z - (PlayerWithInDistance * .5))) != true) &&
           ((Player.x < (Enemy.x + (PlayerWithInDistance * .5)) && Player.z < (Enemy.z - (PlayerWithInDistance * .5))) != true) &&
           ((Player.x < (Enemy.x + (PlayerWithInDistance * .5)) && Player.z > (Enemy.z + (PlayerWithInDistance * .5))) != true)
           )
        {
            PlaySpotted = true;
        }
    }
    

}