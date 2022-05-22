using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField] 
    private GameObject[] _monsterReferenceArray; //массив ссылок на монстров(заполняется в инспекторе)

    private GameObject _spawnedMonster; //ссылка на монстра

    [SerializeField]
    private Transform _leftPos, _rightPos; //позиции спаунера(заполняется в инспекторе)

    private int _randomIndex;             //случайный номер монстра из массива 
    private int _randomSide;              //случайная сторона

    
    void Start()
    {
        StartCoroutine(SpawnMonsters());//включает подпрограмму для генерации монстров
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));// генерирует монстров с интервалом между 1 и 3 сек. 

            _randomIndex = Random.Range(0, _monsterReferenceArray.Length);//устанавливает индекс от 0 до длины массива с монстрами
            _randomSide = Random.Range(0, 2);   //выбирает сторону

            _spawnedMonster = Instantiate(_monsterReferenceArray[_randomIndex]);//выбирает случайную позицию массива и создаёт префаб монстра

            //если индекс стороны 0, то это левая сторона
            if (_randomSide == 0)
            {
                _spawnedMonster.transform.position = _leftPos.position; //установить нового монстра в спаунере слева 
                _spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 15);//установить монстру случайную скорость от 4-10

            }
            else//всё остальное - правая сторона
            {
                _spawnedMonster.transform.position = _rightPos.position; //установить нового монстра в спаунере справа             
                _spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 15);//установить монстру случайную скорость от -4 до -10
                _spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); //повернуть монстра влево лицом изменяя scale на -1
                
            }

        }//while loop всё повторять 
        
    }//Coroutine

}//class
