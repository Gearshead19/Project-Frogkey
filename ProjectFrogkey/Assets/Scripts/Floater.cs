using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public float range;

    private void FixedUpdate()
    {
        //float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);

        if (transform.position.y < range)//waveHeight)
        {
            float displacementMultiplyer = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount;
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplyer, 0f), ForceMode.Acceleration);
        }
    }
}
