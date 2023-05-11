using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_obj : MonoBehaviour
{

    public GameObject spawn_boss;

    private GameObject froggy_player;

    //spawns something that runs away from the player (player has to kill it to stop healing)
    public GameObject heal_life_pod;
    //keeps track of heal life pod
    private GameObject track_heal_life_pod;

    private bool spawned_heal_pod = false;

    public float dis_for_actiavtion = 6;

    private bool already_spawn_boss = false;



    // Start is called before the first frame update
    void Start()
    {
        froggy_player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn_boss != null && already_spawn_boss == false)
        {

        
            if (Vector3.Distance(this.transform.position, froggy_player.transform.position) < dis_for_actiavtion)
            {
                already_spawn_boss = true;
                Instantiate(spawn_boss, this.transform);
            }
        }

        if(spawned_heal_pod == true)
        {
            if (track_heal_life_pod == null)
            {

                Unalive();
            }
        }

    }

    public void Half_time_spawns()
    {
        Instantiate(heal_life_pod, this.transform);
        track_heal_life_pod = GameObject.FindGameObjectWithTag("heal_life_pod_boss");
        spawned_heal_pod = true;
    }

    public void Unalive()
    {
        spawned_heal_pod = false;
        this.gameObject.SetActive(false);
    }
}
