using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshFollow : MonoBehaviour
{

    private Transform FroggyPlayer;

    public NavMeshAgent NavMeshAgent;

    //Build in unity AI Path finding

    void Start()
    {
        FroggyPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (FroggyPlayer != null && NavMeshAgent != null)
        {
            MoveToFroggyPlayer();
        }
    }

    void MoveToFroggyPlayer()
    {
        NavMeshAgent.destination = FroggyPlayer.transform.position;
    }
}
