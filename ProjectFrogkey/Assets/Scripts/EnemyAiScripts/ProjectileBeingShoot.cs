using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBeingShoot : MonoBehaviour
{
    public float SpeedXDirection = 0.0f; //X axis direction of the force being added when shot
    public float SpeedZdirection = 30.0f; //Y axis direction of the force being added when shot
    public float DelayOutOfBoundProtical = 10.0f; // Time until this project after being shot will be destoryed.

    void Start()
    {
        Invoke("OutOfBoundsDestroySelf", DelayOutOfBoundProtical);
    }


    void Update()
    {
        transform.Translate((Time.deltaTime * SpeedXDirection), 0, (Time.deltaTime * SpeedZdirection));
    }
    
    void OutOfBoundsDestroySelf()
    {
        gameObject.SetActive(false);
       //Destroy(this.gameObject);
    }

}
