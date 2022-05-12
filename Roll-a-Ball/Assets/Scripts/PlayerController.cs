using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _finishTextObject;
    [SerializeField] private GameObject _unlockedText;
    [SerializeField] private GameObject _goToExitText;
    [SerializeField] private int _count = 0;
    private Rigidbody _rb;
    private float _movementX;
    private float _movementY;

    public GameObject HiddenWall;
    public TextMeshProUGUI Multi;
    public int Multiplier = 1;
    public GameObject All;


                //Start
    void Start()
    {
            
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
    }
        //Movement vector
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }
                      
        //Physics
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);

        _rb.AddForce(movement * _speed);
    }

        //Triggers
    private void OnTriggerEnter(Collider other)
    {  
        //PickUps
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1 * Multiplier;
            SetCountText();
        }
        //Unlocks hidden bonuses x10 if ordinary collected
        if (other.gameObject.CompareTag("NonCollectable") && _count >= 145)
        {
            other.gameObject.SetActive(false);
            Multiplier = 10;
            _count = _count + 1 * Multiplier;
            SetCountText();
        }
        
            //Finish 
            if (other.gameObject.CompareTag("Finish"))
        {
            All.gameObject.SetActive(false);
            _unlockedText.SetActive(false);
            _goToExitText.SetActive(false);
            Multi.text = "";
            _finishTextObject.SetActive(true);
        }
    }




         //Text set up
    void SetCountText()
    {
        Multiplier = 1;
        Multi.text = "Multiplier x" + Multiplier.ToString();//multi set
        _scoreText.text = "COLLECTED: " + _count.ToString();//score set
        _finishTextObject.SetActive(false);
        _unlockedText.SetActive(false);
        _goToExitText.SetActive(false);

        if (_count >= 100) // unlock hidden pickups x10
        {
            
            Multiplier = 10;
            Multi.text = "Multiplier x" + Multiplier.ToString();
            _scoreText.text = "EXTRA COLLECTED: " + _count.ToString();
            _unlockedText.SetActive(true); //enable hint text
        }
        if (_count >= 300) // collect unlockes and  opens an exit
        {
            
            Multiplier = 100;
            Multi.text = "Multiplier x" + Multiplier.ToString();
            _scoreText.text = "ULTRA COLLECTED: " + _count.ToString();
            _unlockedText.SetActive(false);
            HiddenWall.SetActive(false);
            _goToExitText.SetActive(true); //exit opened text
        }
        if (_count >= 1000)
        {
            Multiplier = 1000;
            Multi.text = "Multiplier x" + Multiplier.ToString();
            _scoreText.text = "MEGABONUS: " + _count.ToString(); ;
            _goToExitText.SetActive(false);
            

        }
        
    }  
                  
}




