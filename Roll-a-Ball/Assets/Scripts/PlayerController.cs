using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject collectedText;
    public GameObject goText;
    private int _count;
    private Rigidbody _rb;
    private float _movementX;
    private float _movementY;
    public GameObject HiddenWall;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        collectedText.SetActive(false);
        goText.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);

        _rb.AddForce(movement * _speed);
    }

    //PickUps
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            SetCountText();
        }
        //wincondition
        if (other.gameObject.CompareTag("Finish") && _count >= 165)
        {

            winTextObject.SetActive(true);
            goText.SetActive(false); 
            countText.text = "";
        }
        //hidden bonuses
        if (other.gameObject.CompareTag("NonCollectable") && _count >= 145)
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            SetCountText();
        }
        if (_count >= 160)
        {
            goText.SetActive(true);
            countText.text = "COLLECTED ULTRA!!!: " + _count.ToString();
            collectedText.SetActive(false);
            HiddenWall.GetComponent<MeshRenderer>().enabled = false;
        }
        
        

    }

    void SetCountText()
    {
        countText.text = "COLLECTED: " + _count.ToString();

        
        if (_count >= 145)
        {
            collectedText.SetActive(true);
            countText.text = "COLLECTED EXTRA!: " + _count.ToString();
        }


    }

}




