
/*
# This code snippet was created by Zelda Hu.
# Date: 2023.06.25
# Version: 01

# COPYRIGHT NOTICE:
# Zelda Hu retains full ownership and intellectual property rights to this code.
# You may use this code for personal and educational purposes only.
# Any commercial or unauthorized use is strictly prohibited.

# PRIVACY DISCLAIMER:
# This code does not collect or store any personal or sensitive information.
# However, please review and ensure compliance with privacy regulations
# applicable to your specific use case and data.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalFarm
{
    /// <summary>
    /// First Person Shooter Controller 
    /// This script is used to control the player's movement and camera rotation.
    /// </summary>
    public class FPSController : MonoBehaviour
    {
        #region Private Members
        private float _rotationAroundY = 0.0f;
        private float _rotationAroundX = 0.0f;
        private Rigidbody _rigidbody;
        #endregion Private Members

        #region Public Members
        public float Speed = 5.0f;
        public float Sensitivity = 100.0f;
        public float ClampAngle = 80.0f;
        public float JumpForce = 2.0f;
        #endregion Public Members

        #region Monobehaviour
        void Start()
        {
            Vector3 rot = transform.localRotation.eulerAngles;
            _rotationAroundY = rot.y;
            _rotationAroundX = rot.x;
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            if (_rigidbody == null)
            {
                _rigidbody = gameObject.AddComponent<Rigidbody>();
                _rigidbody.useGravity = true;
            }
        }

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            _rotationAroundY += mouseX * Sensitivity * Time.deltaTime;
            _rotationAroundX += mouseY * Sensitivity * Time.deltaTime;

            _rotationAroundX = Mathf.Clamp(_rotationAroundX, -ClampAngle, 0);

            Quaternion localRotation = Quaternion.Euler(_rotationAroundX, _rotationAroundY, 0.0f);
            transform.rotation = localRotation;

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveX, 0, moveZ);
            movement = transform.rotation * movement;

            transform.position += movement * Speed * Time.deltaTime;

            if (Input.GetButtonDown("Jump"))
            {
                _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
        #endregion Monobehaviour
    }
}
