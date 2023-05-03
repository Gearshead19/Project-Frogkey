using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Gving Hopps Animations for player inputs
/// </summary>
//requires Game Object to have player Movement Script Component
[RequireComponent(typeof(PlayerMovement))]

public class HoppsAnimation : MonoBehaviour
{
    PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            pm.enabled = !pm.enabled;
            Debug.Log("Did it");
           
        }
    }
}
