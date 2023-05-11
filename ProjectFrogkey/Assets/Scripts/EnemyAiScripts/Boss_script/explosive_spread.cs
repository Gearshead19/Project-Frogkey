using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosive_spread : MonoBehaviour
{
    public GameObject spolion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //nothing regular damage
        }
        else
        {
            if(spolion != null)
            {
                Instantiate(spolion, this.gameObject.transform);
                Destroy(this);
            }
        }
    }
}
