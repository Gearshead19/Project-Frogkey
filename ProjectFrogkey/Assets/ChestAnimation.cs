using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour
{
    AnimationClip clip;
    Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        clip = GetComponent<AnimationClip>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        animation.Play();
        //AnimationHandler();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            if (!animation.Play())
            {
               
            }
        }
    }

}
