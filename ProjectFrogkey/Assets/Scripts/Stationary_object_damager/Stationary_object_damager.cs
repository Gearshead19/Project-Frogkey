using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary_object_damager : MonoBehaviour
{

    public float damage_to_player;
    public float cool_down_time;

    private float timer;
    private bool cool_down = false;

    void Cool_off_wait()
    {
        cool_down = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (cool_down == false)
            {
                cool_down = true;
                collision.gameObject.GetComponent<PlayerHealth>().Player_damaged_by_stationary(damage_to_player);
                Invoke("Cool_off_wait", cool_down_time);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (cool_down == false)
            {
                cool_down = true;
                collision.gameObject.GetComponent<PlayerHealth>().Player_damaged_by_stationary(damage_to_player);
                Invoke("Cool_off_wait", cool_down_time);
            }
        }
    }
}
