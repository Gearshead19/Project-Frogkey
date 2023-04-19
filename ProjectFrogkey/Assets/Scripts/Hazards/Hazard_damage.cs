using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_damage : MonoBehaviour
{
    public float damage_amount = 1;
    public float time_betwean = 0.2f;
    public float relift_distance = 2;

    private GameObject Player = null;

    private void Damage_player()
    {
        Player.GetComponent<PlayerHealth>().Player_damaged_by_stationary(damage_amount);
    }

    private void repeat_damage()
    {
        if (Player != null)
        {
            
            if(Vector3.Distance(Player.gameObject.transform.position, this.gameObject.transform.position) < relift_distance)
            {
                Damage_player();
                Invoke("Damage_player", time_betwean);
            }
            else
            {
                Player = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (Player == null)
            {
                repeat_damage();
            }
        }
    }
}
