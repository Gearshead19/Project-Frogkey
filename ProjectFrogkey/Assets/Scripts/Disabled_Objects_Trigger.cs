using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Disabled_Objects_Trigger : MonoBehaviour
{


    public string ObjectsTagName = "to find them";
    public GameObject[] TagedEnimes;
    private bool check_if_all_gone = false;

    [Tooltip("If everything in objects to check are either all active or all inactive, " +
     "these events will be triggered")]
    [SerializeField]
    private UnityEvent onAllObjectsInactive;

    // Start is called before the first frame update
    void Start()
    {
        TagedEnimes = GameObject.FindGameObjectsWithTag(ObjectsTagName);
    }

    // Update is called once per frame
    void Update()
    {
        if (check_if_all_gone == true)
        {
            //JOse specail script happnes here
        }
    }

    private void FixedUpdate()
    {
        See_if_enemies_gone();
    }


    void See_if_enemies_gone()
    {
        bool Check_in_Scene = false;

        foreach (GameObject notwanted in TagedEnimes)
        {
            if (notwanted != null)//|| notwanted.activeSelf == false)
            {
                Check_in_Scene = true;
            }
        }

        if (Check_in_Scene == false)
        {
            check_if_all_gone = true;
        }
    }
}
