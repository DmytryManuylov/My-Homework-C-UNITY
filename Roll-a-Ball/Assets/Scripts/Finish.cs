using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void Restart()
    {
       SceneManager.LoadScene(0);
    }


    void Start()
    {
        
    }

    
    void Update()
    {

    }
}
