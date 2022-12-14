using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int HealthPoints = 100;

    public MenuEditQuick MenuQuick;

    // Start is called before the first frame update
    void Start()
    {
        //MenuQuick = gameObject.GetComponent<MenuEditQuick>();
    }

    // Update is called once per frame
    void Update()
    {
        QucikReset();
        PlayerDead();
    }

    void QucikReset()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            MenuQuick.ReloadLevel();
        }

    }

    void PlayerDead()
    {
        if(HealthPoints <= 0)
        {
            MenuQuick.ReloadLevel();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("I got shot");
            Destroy(collision.gameObject);
            this.HealthPoints = this.HealthPoints - 1;

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("I got harassed");
            //Destroy(other.gameObject);
            this.HealthPoints = this.HealthPoints - 1;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("I got shot");
            Destroy(other.gameObject);
            this.HealthPoints = this.HealthPoints - 1;

        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("I got harassed");
            //Destroy(other.gameObject);
            this.HealthPoints = this.HealthPoints - 1;
        }*/
    }
}
