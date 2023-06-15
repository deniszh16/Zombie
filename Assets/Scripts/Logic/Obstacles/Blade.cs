﻿using UnityEngine;

namespace Logic.Obstacles
{
    public class Blade : MonoBehaviour
    {
        [Header("Физический компонент")]
        [SerializeField] private Rigidbody2D _rigidbody;

        [Header("Параметры раскачивания")]
        [SerializeField] private float _leftLimit;
        [SerializeField] private float _rightLimit;
        [SerializeField] private float _speed;

        private void Start() =>
            _rigidbody.angularVelocity = 500;

        private void FixedUpdate() =>
            SwingMove();

        private void SwingMove()
        {
            if (transform.rotation.z < _rightLimit && _rigidbody.angularVelocity > 0 &&
                _rigidbody.angularVelocity < _speed)
            {
                _rigidbody.angularVelocity = _speed;
            }
            else if (transform.rotation.z > _leftLimit && _rigidbody.angularVelocity < 0 &&
                     _rigidbody.angularVelocity > -_speed)
            {
                _rigidbody.angularVelocity = -_speed;
            }
        }
    }
}