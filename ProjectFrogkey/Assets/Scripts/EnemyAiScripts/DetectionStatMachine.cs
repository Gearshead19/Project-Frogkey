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

    public GameObject MarkerHolder;
    public GameObject[] Markers= new GameObject[8] { null, null, null, null, null, null, null, null};

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
    
    protected void StartSetupMarkers()
    {
        int Counter = 0;
        Vector3 Player = PlayerFroggy.transform.position;
        Vector3 Enemy = this.transform.position;

        foreach (GameObject markPoint in Markers)
        {
            if (MarkerHolder != null)
            {
                Markers[Counter] = Instantiate(MarkerHolder, this.transform.position, this.transform.rotation);
                Markers[Counter].transform.parent = this.gameObject.transform;
                Counter = Counter + 1;
            }
        }

        if (DropSelect == DectionTypes.ZBoxFrontDetection)
        {
            BoxMarker( -PlayerWithInDistance, PlayerWithInDistance,0, (PlayerWithInDistance * length) );
        }
        else if (DropSelect == DectionTypes.ZDimanondFrontDetection)
        {

        }
        else if (DropSelect == DectionTypes.AreaBoxDetection)
        {
            BoxMarker(-PlayerWithInDistance, PlayerWithInDistance, -PlayerWithInDistance, PlayerWithInDistance);
        }
        else if (DropSelect == DectionTypes.AreaDimaondDetection)
        {

        }
        else if (DropSelect == DectionTypes.XBoxFrontDetection)
        {
            BoxMarker(0, (PlayerWithInDistance * length), - PlayerWithInDistance, PlayerWithInDistance);
        }
        else if (DropSelect == DectionTypes.XDimanondFrontDetection)
        {

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
    
    void BoxMarker(float PosX, float NegX, float PosZ, float NegZ)
    {

            if (Markers[0] != null)
            {
                Markers[0].transform.position = new Vector3(Markers[0].transform.position.x + PosX, Markers[0].transform.position.y, Markers[0].transform.position.z);
            }

            if (Markers[1] != null)
            {
                Markers[1].transform.position = new Vector3(Markers[1].transform.position.x + NegX, Markers[1].transform.position.y, Markers[1].transform.position.z);
            }

            if (Markers[2] != null)
            {
                Markers[2].transform.position = new Vector3(Markers[2].transform.position.x, Markers[2].transform.position.y, Markers[2].transform.position.z + PosZ);
            }

            if (Markers[3] != null)
            {
                Markers[3].transform.position = new Vector3(Markers[3].transform.position.x, Markers[3].transform.position.y, Markers[3].transform.position.z + NegZ);
            }
        
        
        
    }

    void DimanondMarker(float one, float two, float three, float four) //Called for the second set for the diagonals
    {
        if (Markers[4] != null)
        {
        }

        if (Markers[5] != null)
        {
        }

        if (Markers[6] != null)
        {
        }

        if (Markers[7] != null)
        {
        }
    }
}