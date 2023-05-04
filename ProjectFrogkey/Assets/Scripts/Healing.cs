using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    

    Text text;

    public static int healLimit;


    public int healSupply = 3;





    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        healLimit = healSupply;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = healLimit.ToString();
        Debug.Log(text.text);
    }
}
