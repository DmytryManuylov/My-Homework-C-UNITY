using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float          _moveForce = 10f; // скорость
    [SerializeField] private float          _jumpForce = 11f; //сила импульса прыжка
                     private float          _movementX;       //хранит направление
                     private Rigidbody2D    _rb;              //объявляем переменную в которой будем хранить компонент игрока физическое тело
                     private SpriteRenderer _sr;                               //объявляем переменную в которой будем хранить компонент игрока отрисовка спрайта
                     private Animator       _anim;                             //объявляем переменную в которой будем хранить компонент игрока аниматор
                     private string         _WALK_ANIMATION = "Walking";       //устанавливаем анимацию в переменную
                     private bool           _isGrounded;
                     private string         _GROUND_TAG = "Ground";       //устанавливаем тег в переменную
                     private string         _ENEMY_TAG = "Enemy";       //устанавливаем тег врага в переменную
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();//получаем ссылку на компонент игрока физическое тело
        _anim = GetComponent<Animator>(); //получаем ссылку на  компонент игрока аниматор
        _sr = GetComponent<SpriteRenderer>();//получаем ссылку на  компонент игрока отрисовка спрайта

    }
    
    void FixedUpdate()
    {
        Jump();
        Move();
        Animate();

    }

    //Функции 
    void Move()
    {
        _movementX = Input.GetAxisRaw("Horizontal"); //сохраняем значение оси в переменную
        transform.position += new Vector3(_movementX, 0f, 0f) * _moveForce * Time.deltaTime;//передвигаем позицию по направлению оси со скоростью _moveForce плавно(time.deltatime)
    }//Метод движения
    void Animate()
    {
        if (_movementX > 0) //если Х положительный - включить бул "Walking" в переходе аниматора между анимацией Idle к Walk и это приведёт к смене анимации на Walk
        {
            _sr.flipX = false;
            _anim.SetBool(_WALK_ANIMATION, true);
        }
        else if (_movementX < 0) //если Х отрицательный - включить бул "Walking" в переходе аниматора между анимацией Idle к Walk и это приведёт к смене анимации на Walk
        {
            _sr.flipX = true; //перевернуть по Х отображение спрайта
            _anim.SetBool(_WALK_ANIMATION, true);
        }
        else //если Х нейтральный(0) - отключить бул "Walking" в переходе аниматора между анимацией Idle к Walk и это приведёт к смене анимации на Idle
        {
            _anim.SetBool(_WALK_ANIMATION, false);
        }
        

    }//Метод анимации
    void Jump()//Метод прыжка
    {
        if (Input.GetButton("Jump") && _isGrounded) //при любом состоянии кнопки прыжок(зажата,нажата,отпущена) и проверка что на земле пройдена
        {
            _rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);//приложить силу в виде импульса к rigid body2D игрока
            _isGrounded = false;  //установить НЕ на земле
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//проверка на касание 
    {
        if (collision.gameObject.CompareTag(_GROUND_TAG)) //если другой коллайдер имеет тег "Ground", то мы на земле
            _isGrounded = true; //установить на земле
        


        if (collision.gameObject.CompareTag(_ENEMY_TAG)) 
            Destroy(gameObject);//уничтожает игрока при касании с врагом
    }


    private void OnTriggerEnter2D(Collider2D collision)//взаимодействие с триггерами
    {
        if (collision.CompareTag(_ENEMY_TAG)) 
            Destroy(gameObject);//уничтожает игрока при вхождении в триггер врага
    }


}//class
