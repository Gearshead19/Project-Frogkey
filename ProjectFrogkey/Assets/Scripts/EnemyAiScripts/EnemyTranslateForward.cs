using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTranslateForward : MonoBehaviour
{
    private float Speed = 4.0f;

    // It Goes Straight
    void Update()
    {
        this.transform.Translate(0, 0, Speed * Time.deltaTime);
    }
}
