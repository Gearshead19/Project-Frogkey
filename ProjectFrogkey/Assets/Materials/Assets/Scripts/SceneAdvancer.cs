using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneAdvancer : MonoBehaviour
{

    
    public void LoadScene(string levelOne)
    {
        SceneManager.LoadScene(levelOne);
        
    }
 
}
