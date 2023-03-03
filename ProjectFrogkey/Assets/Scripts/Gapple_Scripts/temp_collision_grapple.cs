using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_collision_grapple : MonoBehaviour
{

    public float speed = 10;

    private LayerMask layer_val;

    private bool movein = false;

    private GameObject from_object;

    private Collider hit_box;

    private Vector3 last_known;

    // Start is called before the first frame update
    void Start()
    {
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
        Invoke("hit_box_turn_on", 0.1f);
    }

    private void move_this()
    {
       
        transform.Translate(0, 0, speed * Time.deltaTime);
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

        if (collision.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("touching");
            movein = false;
            hit_box.enabled = false;
            this.from_object.GetComponent<temp_grapple>().check_if_okay_grapple(collision.gameObject.layer, last_known);
            this.transform.position = new Vector3(from_object.transform.position.x, from_object.transform.position.y, from_object.transform.position.z);
            this.transform.rotation = from_object.transform.rotation;
            gameObject.transform.parent = from_object.transform;
        }
    }

    
}
