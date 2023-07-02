
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
using UnityEngine.Events;

namespace AnimalFarm
{
    /// <summary>
    /// This script is used to play audio on collider enter 
    /// </summary>
    public class ColliderEvent : MonoBehaviour
    {
        [SerializeField]
        private ColliderEventWrapper onColliderEnterEventWrapper = new ColliderEventWrapper();

        public event UnityAction<AudioSource> OnColliderEnterEvent
        {
            add => onColliderEnterEventWrapper.AddListener(value);
            remove => onColliderEnterEventWrapper.RemoveListener(value);
        }

        private void OnTriggerEnter(Collider other)
        {
            AudioSource audioSource = other.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                onColliderEnterEventWrapper.Invoke(audioSource);
            }
            if (other.GetComponent<ObjectSpinner>() != null)
            {
                other.GetComponent<ObjectSpinner>().LocateAboveGroundAndStartSpinning();
            }
        }

        [System.Serializable]
        private class ColliderEventWrapper : UnityEvent<AudioSource> { }
    }

}
