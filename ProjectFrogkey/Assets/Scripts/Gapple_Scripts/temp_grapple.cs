using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_grapple : MonoBehaviour
{

    public float grapple_speed;

    public Rigidbody rb;

    public LayerMask thing_able_to_grapple_on;

    public GameObject test_collisoin;

    public float base_grapple_speed_up; //impulse
    private float grapple_speed_up_add = 2; //is caluated in the Calculate_jump method
    public int lob; // divid disance by this to get the grpple_spped_up_add
    private float distance = 10; //distance betwean this and the intended location
    public Vector3 GrappleVec; //saved vector for the targeted grapple location
    public float distance_reset = 2; //when objects get distance_reset close to target location,

    private bool grappling;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.U))//this also part of the grapple test
        {
            Make_detector_move();
        }

        if (grappling == true)
        {

            Grapple_action_go_to();
            Reset_grapple();
        }
    }
    

    private void Make_detector_move()
    {
        //thing_able_to_grapple_on;
        this.test_collisoin.GetComponent<temp_collision_grapple>().activate(thing_able_to_grapple_on, this.gameObject);
    }

    public void check_if_okay_grapple(LayerMask layer, Vector3 position)
    {
        GrappleVec = position;

        if(layer == thing_able_to_grapple_on)
        {
            set_grapple_on();
        }
    }

    private void set_grapple_on()
    {
        ExcuteGrapple();
        grappling = true;
    }

    private void ExcuteGrapple()
    {

        Caluate_jump();
        Grapple_action_up_arc();

    }

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
}
