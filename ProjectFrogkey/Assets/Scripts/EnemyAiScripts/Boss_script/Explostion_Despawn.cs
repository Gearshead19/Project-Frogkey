using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explostion_Despawn : MonoBehaviour
{

    private float time_left = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time_left <= 0)
        {
            destroy_this();
        }
        
    }

    private void FixedUpdate()
    {
        time_left = time_left - 1;
    }

    private void destroy_this()
    {
        Destroy(this.gameObject);
    }
    
}
