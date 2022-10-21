using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLookAt : MonoBehaviour
{

    private Transform FroggyPlayer;
    public float TurretTurnSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        FroggyPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LookToPlayer()
    {
        Vector3 director = FroggyPlayer.position - transform.position;
        Quaternion rotator = Quaternion.LookRotation(director);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotator, TurretTurnSpeed * Time.deltaTime);
    }
}
