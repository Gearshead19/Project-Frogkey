using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health = 100;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {

            Debug.Log("I Got Shot");
            this.Health = this.Health - 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("I am being hit");
            this.Health = this.Health - 1;
            Destroy(other.gameObject);
        }
    }
}
