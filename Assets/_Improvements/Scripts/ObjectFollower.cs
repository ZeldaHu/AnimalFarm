
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
    /// This script is used to follow a target object.
    /// </summary>
    public class ObjectFollower : MonoBehaviour
    {

        #region Private Members
        private float _followSpeed = 5f;  // The speed of following
        private float _delay = 1f;  // The delay to regulate speed
        private Transform _target;  // The target object to follow
        private Vector3 _lastTargetPosition;  // The position of the target object in the previous frame
        private Vector3 _currentVelocity;  // The current velocity of movement
        #endregion Private Members

        #region Public Members
        public string TargetTag = "Player";  // The tag of the object to follow
        public bool CanFollow = false;
        #endregion Public Members

        #region Monobehaviour

        private void Start()
        {
            // Find the target object based on the specified tag
            GameObject targetObject = GameObject.FindGameObjectWithTag(TargetTag);
            if (targetObject != null)
            {
                _target = targetObject.transform;
                _lastTargetPosition = _target.position;
            }
            else
            {
                Debug.LogWarning("No object found with tag: " + TargetTag);
            }
        }

        private void Update()
        {
            if (_target != null && CanFollow)
            {
                // Calculate the desired position to move towards
                Vector3 desiredPosition = _target.position + (_target.position - _lastTargetPosition) * _delay;

                // Move towards the desired position
                transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _currentVelocity, 1f / _followSpeed);

                // Update the last target position for the next frame
                _lastTargetPosition = _target.position;
            }
        }
        #endregion Monobehaviour
    }
}
