using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int HealthPoints = 100;
    public int telescope_hit = 10;
    public int punch_jab = 1;
    public bool set_to_disable = false;

    void Update()
    {
        CheckWhenDead();
    }

    private void CheckWhenDead()
    {
        if (this.HealthPoints < 0)
        {
            if (set_to_disable == true)
            {
                this.gameObject.SetActive(false);
            }
            else if (set_to_disable == false)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("overheadtelescope"))
        {
            Debug.Log("got hit by teloscop");
            this.HealthPoints = this.HealthPoints - telescope_hit;

        }

        if (other.gameObject.CompareTag("punchjab"))
        {
            Debug.Log("got hit by fist");
            this.HealthPoints = this.HealthPoints - punch_jab;
        }

        
    }
}
