using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int HealthPoints = 100;
    public int telescope_hit = 10;
    public int punch_jab = 1;
    public bool set_to_disable = false;

    public float currentEnemyHealth;

    public GameObject particial_trigger;
    
    public float hit_delay_vission_delay = 0.5F;

    private GameObject get_drop_object_holder;
    
    public int  drop_item_number;

    void Start()
    {
        if(particial_trigger != null)
        {
            particial_trigger.SetActive(false);
        }

        get_drop_object_holder = GameObject.FindGameObjectWithTag("get_drop_object_holder");
        
    }

    

    void Show_hit()
    {
        if (particial_trigger != null)
        {
            particial_trigger.SetActive(true);
        }
        Invoke("Reverse_show_hit", hit_delay_vission_delay);
    }

    void Reverse_show_hit()
    {
        if (particial_trigger != null)
        {
            particial_trigger.SetActive(false);
        }
    }

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


            if(get_drop_object_holder != null)
            {
                //0 to the highest in the  array for the prefab Drop_collection_script (Drop_item_hold_array)  it will spawn the object otherwise if it not with in those parameters nothing will happen
                if (drop_item_number > -1)
                {
                    get_drop_object_holder.GetComponent<Drop_item_hold_array>().Upon_death_drop(drop_item_number, this.transform);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("overheadtelescope"))
        {
            Debug.Log("got hit by teloscop");
            Show_hit();
            this.HealthPoints = this.HealthPoints - telescope_hit;

        }

        if (other.gameObject.CompareTag("punchjab"))
        {
            Debug.Log("got hit by fist");
            Show_hit();
            this.HealthPoints = this.HealthPoints - punch_jab;
        }

        
    }
}
