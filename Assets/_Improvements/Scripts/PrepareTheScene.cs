

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
    /// This script is used to prepare the scene for the game.
    /// </summary>
    public class PrepareTheScene : MonoBehaviour
    {
        #region [SerializeField] Private Members
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _canvas;
        [SerializeField] private GameObject _gameCanvas;
        #endregion [SerializeField] Private Members
        #region Monobehaviour
        void OnEnable()
        {
            // Disable the player 
            _canvas.SetActive(false);
            // Enable the game canvas
            _gameCanvas.SetActive(true);
            // Set the player to rotate 
            _player.transform.Rotate(0f, 180f, 0f);
            // Opening the field of view of the camera to have a larger angle of view
            Camera.main.fieldOfView = 50f;

            // this might be here for no reason!!!! 
            foreach (Transform child in this.transform) 
            // transform is the transform of the gameobject this script is attached to
            // you can also write it as this.transform
            // transform is the component at the top right inspector of every gameobject
            // where you see position, rotation, scale
            // so you can access transform.position, transform.rotation, transform.scale
            {
                // just enabling a canvas 
                child.gameObject.SetActive(true);
            }
            // in unity if you want to get a child which is a gameobject parented to another gameobject 
            // in the hierarchy the child is under the parent 
            // it is basically putting stuff into a folder - the elements of the folder are children of the folder

        }

        void Update()
        {
            // I am forcing the player to be at a certain height because the player is not moving up and down.
            _player.transform.position = new Vector3(_player.transform.position.x, 1, _player.transform.position.z);
        }
        #endregion Monobehaviour
    }
}
