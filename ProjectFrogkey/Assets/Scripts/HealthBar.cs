using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image[] fill;


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;  
        slider.value = health;

        for (int i = 0; i < fill.Length; i++)
        {
            fill[i].color = gradient.Evaluate(1f);
        }
        
    }
    public void SetHealth(int health)
    {
        slider.value = health;

        for (int i = 0; i < fill.Length; i++)
        {
            fill[i].color = gradient.Evaluate(slider.normalizedValue);
        }

       
    }
}
    
