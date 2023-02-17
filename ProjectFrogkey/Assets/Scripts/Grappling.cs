using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    [Header("References")]
    private PlayerMovement pm;
    public Transform tonguePoint;
    public Transform mouthTip;
    public LayerMask whatIsGrappleable;
    public LineRenderer lr;
    public Rigidbody rb;
    //public Transform debugTransform;

   // Vector3 mouseWorldPosition = Vector3.zero;

    [Header("Grappling")]
    public float maxGrappleDistance;
    public float grappleDelayTime;
    public float grapple_speed;
    public float base_grapple_speed_up; //impulse
    private float grapple_speed_up_add = 2; //is caluated in the Calculate_jump method
    public int lob; // divid disance by this to get the grpple_spped_up_add
    private float distance = 10; //distance betwean this and the intended location
    public Vector3 GrappleVec; //saved vector for the targeted grapple location
    public float distance_reset = 2; //when objects get distance_reset close to target location,
    //private bool grappling = false;
    //  public LayerMask available_grapple_area; //Make sure this is set to whatIsGround, since the ground is assumed to be grapplable
    // Vertex point is Hit Vertex

      

    private Vector3 grapplePoint;
    public float overshootYAxis;

  


    [Header("Cooldown")]
    public float grapplingCd;
    private float grapplingCdTimer;

    [Header("Input")]//Won't need the input this way because of new input System
    public KeyCode grappleKey = KeyCode.Mouse1;

    private bool grappling;



    private void Start()
    {
        //GrappleVec = new Vector3(20, 4, 9);//just a text
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {



        if (Input.GetKeyDown(grappleKey)) StartGrapple(); //Don't need this input because of Player Input

        if(Input.GetKeyDown(KeyCode.U))//this also part of the grapple test
            {
            ExcuteGrapple();
            grappling = true;
        }


        if (grapplingCdTimer > 0)
        {
            grapplingCdTimer -= Time.deltaTime;
        }
        
        if (grappling == true)
        {
            
            Grapple_action_go_to();
            Reset_grapple();
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
        pm.freeze = true;

        RaycastHit hit;

        //Vector2 screenCenterPoint = new(Screen.width / 2f, Screen.height / 2f);
        //Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        //always maxGrappleDistance
        if (Physics.Raycast(tonguePoint.position, tonguePoint.forward, out hit, maxGrappleDistance, whatIsGrappleable))
        {
            //mouseWorldPosition = hit.point;
            grapplePoint = hit.point;
            Invoke(nameof(ExcuteGrapple), grappleDelayTime);
            // grabbing a variable
            var hitVertex = grapplePoint;

            GrappleVec = grapplePoint;//saves point that is grapple to
            ExcuteGrapple();
            grappling = true;
            if (hit.transform.gameObject.layer == whatIsGrappleable)
            {
                
                //this is the toggle for invoke it

                
                Debug.Log("Hit grapple thing");
            }



        }
        else
        {
            grapplePoint = tonguePoint.position + tonguePoint.forward * maxGrappleDistance;

            Invoke(nameof(StopGrapple), grappleDelayTime);  //not needed
        }
        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);
    }

    private void ExcuteGrapple()
    {
        
       Caluate_jump();
       Grapple_action_up_arc();

    }
    public bool IsGrappling()
    {
        return grappling;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
    public void StopGrapple()
    {
        pm.freeze = false;

        grappling = false;

        grapplingCdTimer = grapplingCd;

        lr.enabled = false;
    }


    void OnGrapple()
    {
        Debug.Log("I'm grappling thing");
        StartGrapple();
        //Vector3 aimDir = (mouseWorldPosition - tonguePoint.position).normalized;


        //if (Physics.Raycast(tonguePoint.position, tonguePoint.forward, 999f, whatIsGrappleable))
        //{
        //    //mouseWorldPosition = hit.point;
        //    //grapplePoint = hit.point;

        //    //// grabbing a variable
        //    //var hitVertex = grapplePoint;

        //    //GrappleVec = hitVertex;//saves point that is grapple to

        //    //if (hit.transform.gameObject.layer == whatIsGrappleable)
        //    //{
        //    //    //Invoke(nameof(ExcuteGrapple), grappleDelayTime);
        //    //    grappling = true;
        //    //    Debug.Log("Hit grapple thing");
        //    //}



        //}

        ////if (ThirdPersonCam.instance.currentStyle == ThirdPersonCam.CameraStyle.Combat)
        ////{
        ////    lr.transform.SetPositionAndRotation(tonguePoint.transform.position, Quaternion.LookRotation(aimDir, Vector3.up));
        ////    StartGrapple();
        ////}
        ////else
        ////{
        ////    StartGrapple();
        ////}
    }


    #region Grapple Physics
    //caluates how high the imulse force is expose to be for the jump depending on the distance
    void Caluate_jump()
    {
        Find_distance_to_gapplepoint();

        int result = (int)distance / lob;
        grapple_speed_up_add = result;
    }

    //Move object towards gapple position
    void Grapple_action_go_to()
    {
        this.transform.position = Vector3.Lerp(transform.position, GrappleVec, Time.deltaTime * grapple_speed); //moves player to location of grapple
    }
    //impact force to create an arc like effect
    void Grapple_action_up_arc()
    {
        rb.AddForce(Vector3.up * (base_grapple_speed_up + grapple_speed_up_add), ForceMode.Impulse);
    }
    //finds the distance to the grapple point
    void Find_distance_to_gapplepoint()
    {
        distance = Vector3.Distance(this.gameObject.transform.position, GrappleVec);
    }
    //Rests grapple when too close
    void Reset_grapple()
    {
        Find_distance_to_gapplepoint();

        if (distance < distance_reset)//how_far)
        {
            grappling = false;
        }
    }
    #endregion
}
