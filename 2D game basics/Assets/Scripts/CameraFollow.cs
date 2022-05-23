using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

                     private Transform _player;
                     private Vector3   _Pos;
    [SerializeField] private float     _minimumX, _maximumX;//устанавливаем в инспекторе координаты за которые камера не может выходить

   
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;//Ищем объект с тегом Игрок и складываем его компонент трансформ в переменную
        Debug.Log("The selected index: " + GameManager.instance.CharIndex);

    }

    
    void LateUpdate()//устанавливаем рамки для камеры
    {
        if (!_player)// если игрок уничтожен (_player == null) то весь код под return пропускается потому что функция VOID
            return;

        _Pos = transform.position; //Записываем текущее значение позиции камеры в переменную _Pos временная позиция
        _Pos.x = _player.position.x;//Устанавливаем Х как у Игрока

        if (_Pos.x < _minimumX)  //Если временная позиция камеры по Х меньше установленного минимального значения, 
            _Pos.x = _minimumX; //то установить в минимально разрешённое положение позиции камеры

        if (_Pos.x > _maximumX) //Если временная позиция камеры по Х болбше установленного максимального значения, 
            _Pos.x = _maximumX; //то установить в максимально разрешённое положение позиции камеры


        transform.position = _Pos;//Присваиваем полученное значение позиции камеры

    }
}
