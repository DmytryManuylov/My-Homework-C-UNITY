using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] private float _speed = 40;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _finishTextObject;
    [SerializeField] private GameObject _unlockedText;
    [SerializeField] private GameObject _goToExitText;
    [SerializeField] private int _count = 0;
    private Rigidbody _rb;
    private float _movementX;
    private float _movementY;

    
    public TextMeshProUGUI Multi;
    public int Multiplier = 1;
    public GameObject All;
    public GameObject whiteBlocks;
    //Start
    void Start()
    {
        whiteBlocks.SetActive(false); // hidden blocks off
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetText();
        
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            SetMultiplier();
            SetCount();
            SetText();
        }
        //Unlocks hidden bonuses x10 if ordinary collected > 100
        if (other.gameObject.CompareTag("NonCollectable") && _count >= 100)
        {
            other.gameObject.SetActive(false);
            SetMultiplier();
            SetCount();
            SetText();
        }
        
        //Finish 
        if (other.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(Next());
            SetMultiplier();
            SetCount();
            All.gameObject.SetActive(false);
            _unlockedText.SetActive(false);
            _goToExitText.SetActive(false);
            Multi.text = "Multiplier x" + Multiplier.ToString();
            _finishTextObject.SetActive(true);
            

        }
       
    }
            //Methods
    void SetMultiplier()
    {
        if (_count < 100)
        {
            Multiplier = 1;
        }
        if (_count >= 100)
        {
            Multiplier = 10;
        }
        else if (_count >= 300)
        {
            Multiplier = 100;
        }
        else if (_count >= 700)
        {
            Multiplier = 1000;
        }
    }
    void SetText()
    {
       
        Multi.text = "Multiplier x" + Multiplier.ToString();//multi set
        _scoreText.text = "COLLECTED: " + _count.ToString();//score set
        _finishTextObject.SetActive(false);
        _unlockedText.SetActive(false);
        _goToExitText.SetActive(false);

        if (_count >= 100) // unlock hidden pickups x10
        {
            whiteBlocks.SetActive(true);
            Multi.text = "Multiplier x" + Multiplier.ToString();
            _scoreText.text = "EXTRA COLLECTED: " + _count.ToString();
            _unlockedText.SetActive(true); //enable hint text
            
        }
        if (_count >= 300) // collect unlockes and  opens an exit
        {
            Multi.text = "Multiplier x" + Multiplier.ToString();
            _scoreText.text = "ULTRA COLLECTED: " + _count.ToString();
            _unlockedText.SetActive(false);
            
            _goToExitText.SetActive(true); //exit opened text
        }
        if (_count >= 700)
        {
           
            Multi.text = "Multiplier x" + Multiplier.ToString();
            _scoreText.text = "MEGABONUS: " + _count.ToString(); ;
            _goToExitText.SetActive(false);
            

        }
        
    }  
    void SetCount()
    {
        _count = _count + 1 * Multiplier;
    }
}







