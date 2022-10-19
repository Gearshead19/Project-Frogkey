using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshFollow : MonoBehaviour
{

    private Transform FroggyPlayer;
    
    public NavMeshAgent NavMeshAgent;

    public Transform PlayerFroggy;
    public int PlayerWithInDistance = 5;
    private bool PlaySpotted = false;
    public GameObject[] Markering;

    //Build in unity AI Path finding

    void Start()
    {
        FroggyPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        NavMeshAgent = GetComponent<NavMeshAgent>();

        PlayerFroggy = GameObject.FindGameObjectWithTag("Player").transform;

    }
    
    void Update()
    {
        
        SeekPlyaerDimaondWithThird();
        //MarkerRadius();

        if (FroggyPlayer != null && NavMeshAgent != null && PlaySpotted == true)
        {
            MoveToFroggyPlayer();
        }
    }

    void MoveToFroggyPlayer()
    {
        NavMeshAgent.destination = FroggyPlayer.transform.position;
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
