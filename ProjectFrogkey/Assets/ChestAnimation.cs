using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour
{
    private Animator animation;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }
    /// <summary>
    /// If the chest collides with the "player" Tag, it activates the "Open" animation.
    /// </summary>
    /// <param any other collider ="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            animation.SetTrigger("Open"); //Opens the chest

            //transform.position = new Vector3(0f, 90f, 152f);// leaves it open.
        }
    }

}
