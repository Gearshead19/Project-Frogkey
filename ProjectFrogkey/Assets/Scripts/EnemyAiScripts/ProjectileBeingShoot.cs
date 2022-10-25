using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBeingShoot : MonoBehaviour
{
    public float SpeedXDirection = 0.0f;
    public float SpeedZdirection = 30.0f;
    public float DelayOutOfBoundProtical = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("OutOfBoundsDestroySelf", DelayOutOfBoundProtical);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Time.deltaTime * SpeedXDirection), 0, (Time.deltaTime * SpeedZdirection));
    }
    
    void OutOfBoundsDestroySelf()
    {
        Destroy(this.gameObject);
    }

}
