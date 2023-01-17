using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    [Header("References")]
    private PlayerMovement pm;
    public Transform cam;
    public Transform mouthTip;
    public LayerMask whatIsGrappleable; //rember to ask N. what this is for since it starts out as whatIsGround, then changes to what ever the objects the raycast hits
    public LineRenderer lr;

    [Header("Grappling")]
    public float maxGrappleDistance;
    public float grappleDelayTime;
    public float grapple_speed; 
    public LayerMask available_grapple_area; //Make sure this is set to whatIsGround, since the ground is assumed to be grapplable

    private Vector3 grapplePoint;

    [Header("Cooldown")]
    public float grapplingCd;
    private float grapplingCdTimer;

    [Header("Input")]
    public KeyCode grappleKey = KeyCode.Mouse1;

    private bool grappling;



    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(grappleKey)) StartGrapple();
       

        if (grapplingCdTimer > 0)
        {
            grapplingCdTimer -= Time.deltaTime;
        }
    }
    private void LateUpdate()
    {
        if(grappling)
          lr.SetPosition(0, mouthTip.position);
        
    }



    private void StartGrapple()
    {
        
        if (grapplingCdTimer > 0) return;
        

        grappling = true;


        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;


            //if(hit.transform.gameObject.layer ==  available_grapple_area)
            //{
                Invoke(nameof(ExcuteGrapple), grappleDelayTime);
            //}
            

        }
        else
        {
            grapplePoint = cam.position + cam.forward * maxGrappleDistance;

            Invoke(nameof(StopGrapple), grappleDelayTime);
        }
        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);
    }

    private void ExcuteGrapple()
    {
        //this.transform.localPosition = Vector3.Lerp(transform.localPosition, grapplePoint, Time.deltaTime * grapple_speed); //moves player to location of grapple
        
    }

    private void StopGrapple()
    {
        grappling = false;

        grapplingCdTimer = grapplingCd;

        lr.enabled = false;
    }


}
