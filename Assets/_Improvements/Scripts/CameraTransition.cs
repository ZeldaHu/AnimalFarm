
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
using Lean.Touch;

namespace AnimalFarm
// if anyone tries to reach to your animal farm script, they will have to go through this script first
{
    /// <summary>
    /// This script is used to transition the camera from the initial position to the tutorial position.
    /// </summary>

    public class CameraTransition : MonoBehaviour
    {
        #region SerializeField] Private Members
        // [SerializeField] private  = Public Members but can be accessed by other scripts
        // the difference between public and serializefield is that public members can be accessed by other scripts, 
        // but serializefield can only be accessed by this script
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _tutorial; 
        [SerializeField] private LeanPinchCamera _leanPinchCamera;
        [SerializeField] private GameObject _leanTouch;
        [SerializeField] private GameObject _FPSController;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private EnablePlayCanvas _enablePlayCanvas;
        #endregion SerializeField] Private Members
        #region Private Members
        private Vector3 _initialPosition; // initial position of the camera
        private Quaternion _initialRotation; // initial rotation of the camera 
        private float _initialNearClipPlane; // initial near clip plane of the camera
        private float _transitionStartTime; // the time when the transition starts
        #endregion Private Members
        #region Public Members
        public bool Transition; // whether the transition is happening
        public float TransitionDuration = 3f; // the duration of the transition
        #endregion Public Members

        #region MonoBehaviour 
        private void Start()
        {
            _initialPosition = _camera.transform.position;
            _initialRotation = _camera.transform.rotation;
            _initialNearClipPlane = _camera.nearClipPlane;
            // I am changing the clipping plane later because initially the games starts as 
            // bird view but then become first person view, so I need to change the clipping plane
        }

        private void Update()
        {
            if (_leanPinchCamera.Zoom < 11f)
            // the pinch camera is from the LeanTouch package and allows the user to zoom in and out
            {
                Transition = true;
                _transitionStartTime = Time.time;
            }

            // this is the part where camera moves if the transition condition is satisfied
            if (Transition)
            {
                float transitionProgress = (Time.time - _transitionStartTime) / TransitionDuration;
                float smoothProgress = Mathf.SmoothStep(0f, 1f, transitionProgress);
                _camera.transform.position = Vector3.Lerp(_initialPosition, _tutorial.position, smoothProgress);
                _camera.transform.rotation = Quaternion.Lerp(_initialRotation, _tutorial.rotation, smoothProgress);

            }
            // whenever the camera arrives at detination position, the transition is over
            // so we take the chance to do some things like disable the pinch camera and lean touch
            if (Vector3.Distance(_camera.transform.position, _tutorial.position) < 0.01f)
            {
                _leanPinchCamera.enabled = false;
                _leanTouch.SetActive(false);
                Transition = false;
                this.enabled = false;
                // this above will call the method OnDisable()
            }
        }

        // this method is called when the script is disabled
        private void OnDisable()
        {
            _FPSController.SetActive(true); // we enable the player controller so you can move around
            _camera.transform.parent = _FPSController.transform; // we make the camera a child of the player controller
            _camera.transform.localPosition = new Vector3(0, 0f, 0); // we set the camera position to the player controller
            _camera.transform.rotation = Quaternion.identity;  // we set the camera rotation to the player controller
            _audioSource.Play();//we play the audio of the farmer 
            _enablePlayCanvas.enabled = true; // we enable the play canvas so you can play the game when the farmer has finished talking 
            // infact the playcanvas is enabled but is not showed or rendered until the farmer has finished the tutorial 
            Rigidbody rigidbody = GetComponent<Rigidbody>(); 
            // we get the rigidbody of the controller and freezing it because 
            // we don't want the player to move around up and down 
            // maybe the ground is irregular and with physics the player was moving 
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            // also we are additionally freezing Y because we don't want the player to move up and down
            // that would add all another set of rules we didn't want to deal with 
        }
        #endregion MonoBehaviour
    }
}
