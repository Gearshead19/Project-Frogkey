using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_player : MonoBehaviour
{
    public float distnace_from = 5;

    private GameObject parent_obj;

    void Update()
    {
        if (parent_obj != null && Vector3.Distance(parent_obj.transform.position, this.transform.position) > distnace_from)
        {
            this.transform.SetParent(null);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            parent_obj = collision.gameObject;
            this.transform.SetParent(parent_obj.transform);
        }
    }
}
