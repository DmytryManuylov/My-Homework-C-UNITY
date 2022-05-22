using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField] 
    private GameObject[] _monsterReferenceArray; //������ ������ �� ��������(����������� � ����������)

    private GameObject _spawnedMonster; //������ �� �������

    [SerializeField]
    private Transform _leftPos, _rightPos; //������� ��������(����������� � ����������)

    private int _randomIndex;             //��������� ����� ������� �� ������� 
    private int _randomSide;              //��������� �������

    
    void Start()
    {
        StartCoroutine(SpawnMonsters());//�������� ������������ ��� ��������� ��������
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));// ���������� �������� � ���������� ����� 1 � 3 ���. 

            _randomIndex = Random.Range(0, _monsterReferenceArray.Length);//������������� ������ �� 0 �� ����� ������� � ���������
            _randomSide = Random.Range(0, 2);   //�������� �������

            _spawnedMonster = Instantiate(_monsterReferenceArray[_randomIndex]);//�������� ��������� ������� ������� � ������ ������ �������

            //���� ������ ������� 0, �� ��� ����� �������
            if (_randomSide == 0)
            {
                _spawnedMonster.transform.position = _leftPos.position; //���������� ������ ������� � �������� ����� 
                _spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 15);//���������� ������� ��������� �������� �� 4-10

            }
            else//�� ��������� - ������ �������
            {
                _spawnedMonster.transform.position = _rightPos.position; //���������� ������ ������� � �������� ������             
                _spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 15);//���������� ������� ��������� �������� �� -4 �� -10
                _spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); //��������� ������� ����� ����� ������� scale �� -1
                
            }

        }//while loop �� ��������� 
        
    }//Coroutine

}//class
