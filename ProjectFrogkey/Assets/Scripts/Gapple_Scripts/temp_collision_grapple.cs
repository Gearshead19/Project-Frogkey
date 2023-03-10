using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_collision_grapple : MonoBehaviour
{
    private GameObject player;

    public float speed = 20;

    private LayerMask layer_val;

    private bool movein = false;

    private GameObject from_object;

    private Collider hit_box;

    private Vector3 last_known;

    public float distance_range = 25;

    private float do_not_touch_player;
    private bool do_not_touch_activated = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        do_not_touch_player = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        hit_box = this.GetComponent<Collider>();
        hit_box.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movein == true)
        {
            move_this();
            last_known = this.transform.position;
            reset_distance();
            player_no_touch();
        }
    }

    private void player_no_touch()
    {
        float check = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        if (do_not_touch_player > check)
        {
            do_not_touch_player = check;
        }
        else if(do_not_touch_activated == false)
        {
            do_not_touch_activated = true;
            Invoke("hit_box_turn_on", 0.2f);
        }
    }

    private void hit_box_turn_on()
    {
        hit_box.enabled = true;
    }


    public void activate(LayerMask layer, GameObject obj)
    {
        from_object = obj;
        layer_val = layer;
        movein = true;
        //Invoke("hit_box_turn_on", 2f);
        do_not_touch_player = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        do_not_touch_activated = false;
    }

    private void move_this()
    {
       
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void reset_distance()
    {
        if (Vector3.Distance(last_known, from_object.transform.position) > distance_range)
        {
            movein = false;
            hit_box.enabled = false;
            this.transform.position = new Vector3(from_object.transform.position.x, from_object.transform.position.y, from_object.transform.position.z);
            this.transform.rotation = from_object.transform.rotation;
            gameObject.transform.parent = from_object.transform;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer ==  layer_val)
        {
            Debug.Log("touching");
            movein = false;
            hit_box.enabled = false;
            this.from_object.GetComponent<temp_grapple>().check_if_okay_grapple(collision.gameObject.layer, last_known);
            this.transform.position = new Vector3(from_object.transform.position.x, from_object.transform.position.y, from_object.transform.position.z);
            this.transform.rotation = from_object.transform.rotation;
            gameObject.transform.parent = from_object.transform;
        }

        if (collision.gameObject.CompareTag("Wall_temp_grapple"))
        {
            Debug.Log("touching");
            movein = false;
            hit_box.enabled = false;
            this.from_object.GetComponent<temp_grapple>().check_if_okay_grapple(collision.gameObject.layer, last_known);
            this.transform.position = new Vector3(from_object.transform.position.x, from_object.transform.position.y, from_object.transform.position.z);
            this.transform.rotation = from_object.transform.rotation;
            gameObject.transform.parent = from_object.transform;
        }
        else if (!(collision.gameObject.CompareTag("Wall_temp_grapple")))
        {
            movein = false;
            hit_box.enabled = false;
            this.transform.position = new Vector3(from_object.transform.position.x, from_object.transform.position.y, from_object.transform.position.z);
            this.transform.rotation = from_object.transform.rotation;
            gameObject.transform.parent = from_object.transform;
        }
    }

    
}
