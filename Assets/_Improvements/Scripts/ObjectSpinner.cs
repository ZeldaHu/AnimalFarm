
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
    /// This script is used to spin the object
    /// this is used for the abimal when they are floating in the sky 
    /// </summary>
    public class ObjectSpinner : MonoBehaviour
    {
        #region Private Members
        private float _heightAboveGround = 20f;  // The distance above the ground
        private float _spinSpeed = 70f; // The speed of spinning
        private float _liftSpeed = 1f; // The speed of lifting
        private bool _spin = false; // The speed of spinning
        private Vector3 _currentPosition;
        private Vector3 _desiredPosition;
        #endregion Private Members
        #region Public Members
        public GameObject _spinningCage;
        #endregion Public Members
        #region Monobehaviour
        private void Update()
        {
            // this will be called every frame in update 
            // but only if the spin is true we are going to spin the object
            if (_spin) 
            // a bool is a conditional statement
            // if you can spin then spin
            {
                // this is a method which is called for spinning the object 
                Spin();
            }

        }
        #endregion Monobehaviour
        #region Public Methods
        /// <summary>
        /// This method is used to locate the object above the ground and start spinning
        /// it is called externally when we are hitting the animal 
        /// </summary>
        public void LocateAboveGroundAndStartSpinning()
        {
            // Disable the object oscillator in the animal if it exists
            if (GetComponent<ObjectOscillator>() != null)
            {
                GetComponent<ObjectOscillator>().enabled = false;
            }
            // bring the object up to the sky
            _currentPosition = transform.position;
            // Calculate the desired position above the ground
            _desiredPosition = new Vector3(transform.position.x, transform.position.y + _heightAboveGround, transform.position.z);
            // set the spinning true and let the object sping 
            // spin is nothing but a bool which is a condition between true and false 
            // if true spin if not dont spin
            _spin = true;
            _spinningCage.SetActive(true);
        }
        #endregion Public Methods
        #region Private Methods
        private void Spin()
        {
            if (Vector3.Distance(_currentPosition, _desiredPosition) > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, _desiredPosition, _liftSpeed * Time.deltaTime);
            }
            transform.Rotate(Vector3.up, _spinSpeed * Time.deltaTime);
            transform.Rotate(Vector3.right, _spinSpeed * Time.deltaTime);
            transform.Rotate(Vector3.forward, _spinSpeed * Time.deltaTime);
        }
        #endregion Private Methods
    }
}
