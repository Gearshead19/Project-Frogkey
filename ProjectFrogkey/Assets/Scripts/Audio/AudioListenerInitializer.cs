using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerInitializer : MonoBehaviour
{
    // adds audio listener component - should be used on cameras
    void Start()
    {
        gameObject.AddComponent<AkAudioListener>();
    }
}
