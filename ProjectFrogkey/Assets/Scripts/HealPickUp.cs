using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUp : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider col)
    {
        if (Healing.healLimit >= 3)
        {
            Debug.Log("Can't pick up! Max amount of Healing Supply!");
            return;
        }
        if (col.gameObject.tag == "Player")
        {
            Healing.healLimit++;
            Debug.Log("Healing Potion Picked Up!");
            Destroy(gameObject);
        }
        
    }

}
