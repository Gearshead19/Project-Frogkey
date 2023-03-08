using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation, playerCam;
    private Rigidbody rb;
    private PlayerMovement pm;

    [Header("Dashing")]
    public float dashForce, dashUpwardForce,dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }


    // [Header("Input")]
    //Keycode E


    //float Force = rb.mass * acceleration;
    //Debug.Log("I'm Dashing");
    //    if (grounded && state != MovementState.dashing)
    //    {
    //        this.gameObject.GcetComponent<PlayerHealth>().Player_Invincible(time_for_invincbility);
    //rb.AddForce(Force* moveDirection, ForceMode.Impulse);
    //        state = MovementState.dashing;
    //        Invoke(nameof(ResetDash), dashDuration);
}
