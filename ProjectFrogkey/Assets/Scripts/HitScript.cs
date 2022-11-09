using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public GameObject OverHeadTS;
    public GameObject PunchJab;

    private bool ClearToHitStuff = true;

    public float DelayOVerHeadTSHit = 1.0f;
    public float DelayPunchJabHit = 0.1f;
    public float DelayDisappear = 0.1f;

    void Start()
    {
        OverHeadTS = GameObject.FindGameObjectWithTag("overheadtelescope");
        PunchJab = GameObject.FindGameObjectWithTag("punchjab");

        OverHeadTS.SetActive(false);
        PunchJab.SetActive(false);
    }

    void Update()
    {
        OverHeadTSHit();
        PunchJabHit();
    }

    private void PunchJabHit()
    {
        if(Input.GetKeyDown(KeyCode.J) && ClearToHitStuff == true)
        {
            PunchJab.SetActive(true);
            ClearToHitStuff = false;
            Invoke("setitinactive", DelayDisappear);
            Invoke("WaitToHit", DelayPunchJabHit);
        }
    }

    private void OverHeadTSHit()
    {
        if (Input.GetKeyDown(KeyCode.H) && ClearToHitStuff == true)
        {
            OverHeadTS.SetActive(true);
            ClearToHitStuff = false;
            Invoke("setitinactive", DelayDisappear);
            Invoke("WaitToHit", DelayOVerHeadTSHit);

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
