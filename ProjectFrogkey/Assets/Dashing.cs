using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation, playerCam;
    private Rigidbody rb;
    private PlayerMovement pm;
    private MeshTrail dashTrail;

    [Header("Dashing")]
    public float dashForce;
    public float dashDuration;
    public float dashUpwardForce;
    public float maxDashYSpeed;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;

    [Header("Settings")]
    public bool useCameraForward = true;
    public bool allowAllDirections = true;
    public bool disableGravity = false;
    public bool resetVel = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
        dashTrail = GetComponentInChildren<MeshTrail>();
    }


    [Header("Input")]
    public KeyCode dashKey = KeyCode.V;

    private void Update()
    {
        if (Input.GetKeyDown(dashKey))
        {
            Dash();
            
        }
        if (dashCdTimer > 0)
            dashCdTimer -= Time.deltaTime;
    }

    public void Dash()
    {
        if (dashCdTimer > 0) return;
        else dashCdTimer = dashCd;

        Transform forwardT;
        if (useCameraForward)
        {
            forwardT = playerCam;
        }
        else
            forwardT = orientation;

        pm.dashing = true;
        pm.MaxYspeed = maxDashYSpeed;

        Vector3 direction = GetDirection(forwardT);
        Vector3 forcetoApply = direction * dashForce + orientation.up * dashUpwardForce;

        if (disableGravity)
        {
            rb.useGravity = false;
        }
        //dashTrail.Update();

        delayedForceToApply = forcetoApply;
        Invoke(nameof(DelayedDashForce),0.025f);

        Invoke(nameof(ResetDash), dashDuration);


      
    }
    private Vector3 delayedForceToApply;
    private void DelayedDashForce()
    {
        if (resetVel)
        {
            rb.velocity = Vector3.zero;
        }
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }
    private void ResetDash()
    {
        pm.dashing = false;
        pm.MaxYspeed = 0;

        if (disableGravity)
        {
            rb.useGravity = true;
        }
    }

    private Vector3 GetDirection(Transform forwardT)
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3();

        if (allowAllDirections)
        {
            direction = forwardT.forward * verticalInput + forwardT.right * horizontalInput;
            //direction = pm.moveDirection * verticalInput + pm.moveDirection * horizontalInput;

        }
        else
        {
            direction = forwardT.forward;
        }
        if (verticalInput == 0 && horizontalInput == 0)
        {
            //direction = forwardT.forward;

            // Dashes in the direction of the player model's look direction.
            direction = pm.playerModelLook.forward;
        }
        return direction.normalized;
    }
    //float Force = rb.mass * acceleration;
    //Debug.Log("I'm Dashing");
    //    if (grounded && state != MovementState.dashing)
    //    {
    //        this.gameObject.GcetComponent<PlayerHealth>().Player_Invincible(time_for_invincbility);
    //rb.AddForce(Force* moveDirection, ForceMode.Impulse);
    //        state = MovementState.dashing;
    //        Invoke(nameof(ResetDash), dashDuration);

    //public void Trailin()
    //{
    //    if (!isTrailActive)
    //    {
    //        isTrailActive = true;
    //        StartCoroutine(ActivateTrail(activeTime));
    //    }
    //}
}
