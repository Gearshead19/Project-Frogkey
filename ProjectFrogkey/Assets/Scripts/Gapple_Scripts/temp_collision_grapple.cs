using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_collision_grapple : MonoBehaviour
{

    public float speed = 10;

    private LayerMask layer_val;

    private bool movein = false;

    private GameObject from_object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movein == true)
        {
            move_this();
        }
    }

    public void activate(LayerMask layer, GameObject obj)
    {
        from_object = obj;
        layer_val = layer;
        movein = true;
    }

    private void move_this()
    {
       
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer ==  layer_val)
        {
            movein = false;
            this.from_object.GetComponent<temp_grapple>().check_if_okay_grapple(collision.gameObject.layer, this.transform.position);
        }
    }
}
