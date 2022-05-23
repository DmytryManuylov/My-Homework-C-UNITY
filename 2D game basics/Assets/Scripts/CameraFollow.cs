using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

                     private Transform _player;
                     private Vector3   _Pos;
    [SerializeField] private float     _minimumX, _maximumX;//������������� � ���������� ���������� �� ������� ������ �� ����� ��������

   
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;//���� ������ � ����� ����� � ���������� ��� ��������� ��������� � ����������
        Debug.Log("The selected index: " + GameManager.instance.CharIndex);

    }

    
    void LateUpdate()//������������� ����� ��� ������
    {
        if (!_player)// ���� ����� ��������� (_player == null) �� ���� ��� ��� return ������������ ������ ��� ������� VOID
            return;

        _Pos = transform.position; //���������� ������� �������� ������� ������ � ���������� _Pos ��������� �������
        _Pos.x = _player.position.x;//������������� � ��� � ������

        if (_Pos.x < _minimumX)  //���� ��������� ������� ������ �� � ������ �������������� ������������ ��������, 
            _Pos.x = _minimumX; //�� ���������� � ���������� ����������� ��������� ������� ������

        if (_Pos.x > _maximumX) //���� ��������� ������� ������ �� � ������ �������������� ������������� ��������, 
            _Pos.x = _maximumX; //�� ���������� � ����������� ����������� ��������� ������� ������


        transform.position = _Pos;//����������� ���������� �������� ������� ������

    }
}
