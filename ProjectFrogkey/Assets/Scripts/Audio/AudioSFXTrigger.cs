using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXTrigger : MonoBehaviour
{
    public void PlayButtonSFX()
    {
        AkSoundEngine.PostEvent("Play_Button_Activate", gameObject);
    }   
    
    public void PlayDungeonDoorOpenSFX()
    {
        AkSoundEngine.PostEvent("Play_ForestDungeon_BasicDoor_Open", gameObject);
    }

    public void PlaySwitchTriggerSFX()
    {
        AkSoundEngine.PostEvent("Play_Crystal_Activate", gameObject);
    }

    public void PlayKeyPickupSFX()
    {
        AkSoundEngine.PostEvent("Play_Key_Pickup", gameObject);
    }
}
