using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate1 : MonoBehaviour
     
{
    public float speed = 5.0f;
    void Update()
    {
        transform.Rotate(new Vector3(-37, -60, -45) * speed * Time.deltaTime);
    }
}
