using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        public Vector3 offset;

        void Start()
        {
            offset = transform.position - _player.transform.position;
            offset.y = 2.7f;
            offset.z = -1.45f;
        }
            
        void LateUpdate()
        {
            transform.position = _player.transform.position + offset;
        }

    }

