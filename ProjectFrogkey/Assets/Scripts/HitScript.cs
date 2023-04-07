using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public GameObject OverHeadTS;
    public GameObject PunchJab;
    Animator animator;
   

    private bool ClearToHitStuff = true;

    public float DelayOVerHeadTSHit = 1.0f;
    public float DelayPunchJabHit = 0.1f;
    public float DelayDisappear = 0.1f;

    private GameObject HoldPostion;

    //The lines below are to play audio implemented from Wwise
    public AK.Wwise.Event BasicAttack;
    public AK.Wwise.Event HeavyAttack;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        OverHeadTS = GameObject.FindGameObjectWithTag("overheadtelescope");
        PunchJab = GameObject.FindGameObjectWithTag("punchjab");
        HoldPostion = GameObject.FindGameObjectWithTag("hit_and_jab_holder");
        OverHeadTS.SetActive(false);
        PunchJab.SetActive(false);
    }

    void MoveWithPlayer()
    {
        OverHeadTS.transform.position = new Vector3(HoldPostion.transform.position.x, HoldPostion.transform.position.y, HoldPostion.transform.position.z);
        OverHeadTS.transform.rotation = HoldPostion.transform.rotation;
        PunchJab.transform.position = new Vector3(HoldPostion.transform.position.x, HoldPostion.transform.position.y, HoldPostion.transform.position.z);
        PunchJab.transform.rotation = HoldPostion.transform.rotation;
    }

    void Update()
    {
        MoveWithPlayer();

    }
    public void OnAttack1Heavy()
    {
        OverHeadTSHit();
        
    }

    public void OnAttack2Light()
    {
        PunchJabHit();
    }
    private void PunchJabHit()
    {
        if(ClearToHitStuff == true)
        {
            animator.SetTrigger("LightAttack");
            PunchJab.SetActive(true);
            ClearToHitStuff = false;
            Invoke("setitinactive", DelayDisappear);
            Invoke("WaitToHit", DelayPunchJabHit);
            //The line below plays the BasicAttack audio event
            BasicAttack.Post(gameObject);
        }
    }

    private void OverHeadTSHit()
    {
        if (ClearToHitStuff == true)
        {
            animator.SetTrigger("HeavyAttack");
            OverHeadTS.SetActive(true);
            ClearToHitStuff = false;
            Invoke("setitinactive", DelayDisappear);
            Invoke("WaitToHit", DelayOVerHeadTSHit);
            HeavyAttack.Post(gameObject);
        }
    }

    private void setitinactive()
    {
        OverHeadTS.SetActive(false);
        PunchJab.SetActive(false);
    }

    private void WaitToHit()
    {
        ClearToHitStuff = true;
    }

}
