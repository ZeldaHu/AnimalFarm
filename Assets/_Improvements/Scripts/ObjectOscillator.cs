
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
using UnityEngine;

namespace AnimalFarm
{
    /// <summary>
    /// This script is used to rotate an object back and forth on its local Z-axis
    /// </summary>
    public class ObjectOscillator : MonoBehaviour
    {
        #region Private Members
        private Quaternion _startRotation;
        private float _currentRotation;
        #endregion Private Members
        #region Public Members
        public float RotationSpeed = 10f; // Speed of rotation on local Z-axis
        public float RotationRange = 30f; // Range of rotation on local Z-axis
        public float YRotationRange = 180f; // Range of randomization for Y rotation
        #endregion Public Members
        #region Monobehaviour

        private void Start()
        {
            // Store the initial rotation
            _startRotation = transform.rotation;

            // Randomize the Y rotation
            float yRotation = Random.Range(-YRotationRange, YRotationRange);
            // noticed that it should have been the z axis but 
            // because these models are probably imported 
            // by another software there is a change in axis rotation 
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        }

        private void Update()
        {
            // Rotate the object on its local Z-axis back and forth
            _currentRotation += RotationSpeed * Time.deltaTime;
            // sinusoidal function to rotate the object back and forth
            float zRotation = Mathf.Sin(_currentRotation) * RotationRange;
            transform.rotation = _startRotation * Quaternion.Euler(0f, 0f, zRotation);
        }
        #endregion Monobehaviour
    }
}
