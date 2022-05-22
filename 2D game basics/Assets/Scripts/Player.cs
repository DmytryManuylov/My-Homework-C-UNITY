using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float          _moveForce = 10f; // ��������
    [SerializeField] private float          _jumpForce = 11f; //���� �������� ������
                     private float          _movementX;       //������ �����������
                     private Rigidbody2D    _rb;              //��������� ���������� � ������� ����� ������� ��������� ������ ���������� ����
                     private SpriteRenderer _sr;                               //��������� ���������� � ������� ����� ������� ��������� ������ ��������� �������
                     private Animator       _anim;                             //��������� ���������� � ������� ����� ������� ��������� ������ ��������
                     private string         _WALK_ANIMATION = "Walking";       //������������� �������� � ����������
                     private bool           _isGrounded;
                     private string         _GROUND_TAG = "Ground";       //������������� ��� � ����������
                     private string         _ENEMY_TAG = "Enemy";       //������������� ��� ����� � ����������
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();//�������� ������ �� ��������� ������ ���������� ����
        _anim = GetComponent<Animator>(); //�������� ������ ��  ��������� ������ ��������
        _sr = GetComponent<SpriteRenderer>();//�������� ������ ��  ��������� ������ ��������� �������

    }
    
    void FixedUpdate()
    {
        Jump();
        Move();
        Animate();

    }

    //������� 
    void Move()
    {
        _movementX = Input.GetAxisRaw("Horizontal"); //��������� �������� ��� � ����������
        transform.position += new Vector3(_movementX, 0f, 0f) * _moveForce * Time.deltaTime;//����������� ������� �� ����������� ��� �� ��������� _moveForce ������(time.deltatime)
    }//����� ��������
    void Animate()
    {
        if (_movementX > 0) //���� � ������������� - �������� ��� "Walking" � �������� ��������� ����� ��������� Idle � Walk � ��� ������� � ����� �������� �� Walk
        {
            _sr.flipX = false;
            _anim.SetBool(_WALK_ANIMATION, true);
        }
        else if (_movementX < 0) //���� � ������������� - �������� ��� "Walking" � �������� ��������� ����� ��������� Idle � Walk � ��� ������� � ����� �������� �� Walk
        {
            _sr.flipX = true; //����������� �� � ����������� �������
            _anim.SetBool(_WALK_ANIMATION, true);
        }
        else //���� � �����������(0) - ��������� ��� "Walking" � �������� ��������� ����� ��������� Idle � Walk � ��� ������� � ����� �������� �� Idle
        {
            _anim.SetBool(_WALK_ANIMATION, false);
        }
        

    }//����� ��������
    void Jump()//����� ������
    {
        if (Input.GetButton("Jump") && _isGrounded) //��� ����� ��������� ������ ������(������,������,��������) � �������� ��� �� ����� ��������
        {
            _rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);//��������� ���� � ���� �������� � rigid body2D ������
            _isGrounded = false;  //���������� �� �� �����
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//�������� �� ������� 
    {
        if (collision.gameObject.CompareTag(_GROUND_TAG)) //���� ������ ��������� ����� ��� "Ground", �� �� �� �����
            _isGrounded = true; //���������� �� �����
        


        if (collision.gameObject.CompareTag(_ENEMY_TAG)) 
            Destroy(gameObject);//���������� ������ ��� ������� � ������
    }


    private void OnTriggerEnter2D(Collider2D collision)//�������������� � ����������
    {
        if (collision.CompareTag(_ENEMY_TAG)) 
            Destroy(gameObject);//���������� ������ ��� ��������� � ������� �����
    }


}//class
