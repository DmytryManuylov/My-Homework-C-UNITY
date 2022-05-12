using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button : MonoBehaviour
{

    public GameObject TriggeredDoor;
    void OnTriggerEnter(Collider other)
    {
        TriggeredDoor.SetActive(false);
        transform.localPosition -= new Vector3(0, 0.19f, 0);
        GetComponent<Renderer>().material.color = new Color(1, 0, 0);
    }

    void OnTriggerExit(Collider other)
    {
        TriggeredDoor.SetActive(true);
        transform.localPosition += new Vector3(0, 0.19f, 0);
        GetComponent<Renderer>().material.color = new Color(0, 1, 0);
    }
}