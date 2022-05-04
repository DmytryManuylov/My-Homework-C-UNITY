using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour

{
    public float speed = 1.0f;

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * speed * Time.deltaTime);
    }
}
