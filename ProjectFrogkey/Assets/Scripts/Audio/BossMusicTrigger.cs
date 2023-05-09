using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusicTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AkSoundEngine.SetState("PlayingSong", "Music_ForestDungeonBoss");
            Debug.Log("Playing boss music");
            Destroy(gameObject);
        }
    }
}
