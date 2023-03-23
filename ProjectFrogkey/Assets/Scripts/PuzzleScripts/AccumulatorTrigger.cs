using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This object collects messages sent from other sources,
/// and once it has collected the required number of messages,
/// it triggers something.
/// </summary>
public class AccumulatorTrigger : MonoBehaviour
{
    [Tooltip("How many messages are required before triggering")]
    [SerializeField]
    private int numberRequired;

    [Tooltip("The event that fires off when the required number of messages has been received")]
    [SerializeField]
    private UnityEvent OnRequiredNumberRecieved;

    [Tooltip("KEEP INITIALIZED AT 0 UNLESS DEBUGGING")]
    [SerializeField]
    private int numberRecieved = 0;

    private bool hasBeenTriggered;

    private void Start()
    {
        // initialize numberReceived to 0 if not testing in the editor as a safety fallback 
#if !UNITY_EDITOR
        numberRecieved = 0;
#endif
    }

    /// <summary>
    /// Increments the number of messages recieved.
    /// If the numberRequired is reached, the trigger fires off.
    /// </summary>
    public void Increment()
    {
        if (hasBeenTriggered) return;

        numberRecieved++;
        if (numberRecieved >= numberRequired)
        {
            OnRequiredNumberRecieved?.Invoke();
            hasBeenTriggered = true;
        }
    }
}