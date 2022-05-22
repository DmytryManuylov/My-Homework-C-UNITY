using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")||collision.CompareTag("Player"))//Если в триггер попал объект с тегом Враг или Игрок, 
            Destroy(collision.gameObject);//то он уничтожается
    }
}
