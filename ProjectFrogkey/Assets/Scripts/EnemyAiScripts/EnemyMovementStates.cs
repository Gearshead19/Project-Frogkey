using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnmeyMovementTypes
{
        RunAway, NavMeshFollow, LookDirFollow, GridBasedFollow
}

public class EnemyMovementStates : DetectionStatMachine
{

    public EnmeyMovementTypes FollowList = new EnmeyMovementTypes();

    public NavMeshAgent NavMeshAgent;

    public GameObject FroggyPlayer;

    public float speed = 1.0f;

    [SerializeField]
    private IsOkayShootLookAhead check_shoot;
    private int shoot_range = 10;
    public bool shooter = false;

    void Start()
    {
        FroggyPlayer = GameObject.FindGameObjectWithTag("FindPlayer");
        NavMeshAgent = GetComponent<NavMeshAgent>();
        PlayerFroggy = GameObject.FindGameObjectWithTag("FindPlayer").transform;

        if(this.gameObject.GetComponent<IsOkayShootLookAhead>() != null)
        {
            shooter = true;
            check_shoot = this.gameObject.GetComponent<IsOkayShootLookAhead>();
            shoot_range = check_shoot.ShootRange;

        }
        else
        {
            shooter = false;
        }

        StartSetupMarkers();//this is only for testing purpose to see the radius of the detection range
    }


    void Update()
    {

        if (PlayerFroggy != null && PlaySpotted == false)
        {
            DetectionStateCheck();//DetecionState
        }
        else if (shooter == true && Vector3.Distance(PlayerFroggy.position, this.transform.position) < (shoot_range - 2))
        {
            ShooterStop();
        }
        else if (PlayerFroggy != null && PlaySpotted == true)
        {
            CheckMovementType();

            StopFollowing();
        }
    }

    void CheckMovementType()
    {
        if(FollowList == EnmeyMovementTypes.RunAway)
        {
            RunAwayFrom();
        }
        else if (FollowList == EnmeyMovementTypes.NavMeshFollow && NavMeshAgent != null)
        {
            NavmeshMoveToPlayer();
        }
        else if (FollowList == EnmeyMovementTypes.LookDirFollow)
        {
            LookAtPlayer();
            MoveForward();
        }
        else if (FollowList == EnmeyMovementTypes.GridBasedFollow)
        {
            GridfollowPlayer();
        }
    }

    private void RunAwayFrom()
    {
        if (PlayerFroggy.transform.position.x > this.transform.position.x)
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

    private void ShooterStop()
    {
            this.transform.Translate(0, 0, 0);
        
    }

    void LookAtPlayer()//
    {
        Vector3 director = PlayerFroggy.position - transform.position; //This finds the distance from were it is to were it want to go
        Quaternion rotator = Quaternion.LookRotation(director); // This uses the director to look to the direction its going
        transform.rotation = Quaternion.Lerp(transform.rotation, rotator, speed * Time.deltaTime); //this rotate it 
    }

    void MoveForward()//
    {
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void NavmeshMoveToPlayer()
    {
        NavMeshAgent.destination = FroggyPlayer.transform.position;
    }

    private float Xing;
    private float Zing;
    bool PostiveX;
    bool PostiveY;

    void GridfollowPlayer()
    {
        
            Xing = FroggyPlayer.transform.position.x;
            Zing = FroggyPlayer.transform.position.z;

            PostiveX = FroggyPlayer.transform.position.x <= 0;
            PostiveY = FroggyPlayer.transform.position.z <= 0;

            if (Xing > transform.position.x + 1)
            {
                if (Zing > transform.position.z + 1)
                {
                    transform.Translate(speed * Time.deltaTime, 0, speed * Time.deltaTime);
                }
                else if (Zing < transform.position.z - 1)
                {
                    transform.Translate(speed * Time.deltaTime, 0, -speed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(speed * Time.deltaTime, 0, 0);
                }
            }
            else if (Xing < transform.position.x - 1)
            {
                if (Zing > transform.position.z + 1)
                {
                    transform.Translate(-speed * Time.deltaTime, 0, speed * Time.deltaTime);
                }
                else if (Zing < transform.position.z - 1)
                {
                    transform.Translate(-speed * Time.deltaTime, 0, -speed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(-speed * Time.deltaTime, 0, 0);
                }

            }
            else if (Zing > transform.position.z + 1)
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
            else if (Zing < transform.position.z - 1)
            {
                transform.Translate(0, 0, -speed * Time.deltaTime);
            }
        
    }




}
