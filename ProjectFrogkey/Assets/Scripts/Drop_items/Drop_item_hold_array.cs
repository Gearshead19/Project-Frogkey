using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_item_hold_array : MonoBehaviour
{
    public GameObject[] items_drop_upon_death;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Upon_death_drop(int item_num, Transform location)
    {
        if(item_num < items_drop_upon_death.Length)
        {

            Instantiate(items_drop_upon_death[item_num], location.transform.position, location.transform.rotation);

        }
        else
        {
            Debug.Log("The array is the length of " + items_drop_upon_death.Length + " , and it turns out " + item_num + " is not included under that number...");
        }
    }
}
