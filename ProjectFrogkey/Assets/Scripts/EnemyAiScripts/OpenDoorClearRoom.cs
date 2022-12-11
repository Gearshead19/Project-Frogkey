using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorClearRoom : MonoBehaviour
{

    public GameObject LeftDoor;
    public GameObject RightDoor;
    
    public string ObjectsTagName = "to find them";
    public GameObject[] TagedEnimes;
    private bool DoorOpen = false;
    private bool StopOpening = false;

    private float speedRotate = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        TagedEnimes = GameObject.FindGameObjectsWithTag(ObjectsTagName);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (DoorOpen == true && StopOpening == false)
        {
            Open_left_door();
            Open_right_door();
        }

        if (RightDoor.transform.localRotation.y > 0)
        {
            StopOpening = true;
        }
    }

    private void FixedUpdate()
    {
        See_if_enimes_gone();
    }

    void See_if_enimes_gone()
    {
        bool Check_in_Scene = false;

        foreach (GameObject notwanted in TagedEnimes)
        {
            if (notwanted != null )//|| notwanted.activeSelf == false)
            {
                Check_in_Scene = true;
            }
        }

        if (Check_in_Scene == false)
        {
            DoorOpen = true;
        }
    }
    

    void Open_left_door()
    {
        if(LeftDoor != null)
        {
            LeftDoor.transform.Rotate(0, -(speedRotate * Time.deltaTime), 0);
            
        }
    }

    void Open_right_door()
    {
        if (RightDoor != null)
        {
            RightDoor.transform.Rotate(0, (speedRotate * Time.deltaTime), 0);
            
        }
    }
}
