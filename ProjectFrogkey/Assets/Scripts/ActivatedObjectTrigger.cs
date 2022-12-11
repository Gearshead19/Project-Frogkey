using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Trigger that fires off if all objects are activated or deactivated.
/// </summary>
public class ActivatedObjectTrigger : MonoBehaviour
{
    [Tooltip("Check these objects and trigger when they are all active or all inactive")]
    [SerializeField]
    private GameObject[] objectsToCheck;

    [Tooltip("If everything in objects to check are either all active or all inactive, " +
        "these events will be triggered")]
    [SerializeField]
    private UnityEvent onAllObjectsActive;

    [Tooltip("If everything in objects to check are either all active or all inactive, " +
     "these events will be triggered")]
    [SerializeField]
    private UnityEvent onAllObjectsInactive;

    private bool hasOnAllObjectsActiveTriggered = false;
    private bool hasOnAllObjectsInactiveTriggered = false;


    private void FixedUpdate()
    {
            CheckObjectStatus();
    }

    public void CheckObjectStatus()
    {
        if (!hasOnAllObjectsActiveTriggered)
        {
            bool isEveryObjectActive = true;
            foreach (var item in objectsToCheck)
            {
                if (!item.activeSelf)
                    isEveryObjectActive = false;
            }

            if (isEveryObjectActive)
            {
                onAllObjectsActive.Invoke();
                hasOnAllObjectsActiveTriggered = true;
            }
        }
  
    if (!hasOnAllObjectsInactiveTriggered)
        {
            bool isEveryObjectInactive = true;
            foreach (var item in objectsToCheck)
            {
                if (item.activeSelf)
                    isEveryObjectInactive = false;
            }

            if (isEveryObjectInactive)
            {
                onAllObjectsInactive.Invoke();
                hasOnAllObjectsInactiveTriggered = true;
            }
        }
    }
}