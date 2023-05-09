using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_obj : MonoBehaviour
{

    public GameObject spawn_boss;

    private GameObject froggy_player;

    public float dis_for_actiavtion = 6;

    // Start is called before the first frame update
    void Start()
    {
        froggy_player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn_boss != null)
        {

        
            if (Vector3.Distance(this.transform.position, froggy_player.transform.position) < dis_for_actiavtion)
            {

                Instantiate(spawn_boss, this.transform);
            }
        }

    }
}
