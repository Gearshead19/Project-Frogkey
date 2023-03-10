using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectionZplane : MonoBehaviour
{

    public Transform PlayerFroggy;
    private bool PlaySpotted = false;
    private bool EnemyStopFollow = false;
    public int StopFollowDistance = 20;
    public int PlayerWithInDistance = 10;
    // Start is called before the first frame update
    void Start()
    {
        PlayerFroggy = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (PlayerFroggy.transform.position.z > this.transform.position.z &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + (PlayerWithInDistance * 2)) &&
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
}
