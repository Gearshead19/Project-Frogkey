using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_obj : MonoBehaviour
{

    public GameObject spawn_boss;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawn_boss, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
