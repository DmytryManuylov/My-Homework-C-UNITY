using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private Vector3 _offset;

        void Start()
        {
            _offset = transform.position - _player.transform.position;
            _offset.y = 2.7f;
            _offset.z = -1.45f;
        }
            
        void LateUpdate()
        {
            transform.position = _player.transform.position + _offset;
        }

    }

