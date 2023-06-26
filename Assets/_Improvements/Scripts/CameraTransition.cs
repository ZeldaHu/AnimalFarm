using System.Collections;
using UnityEngine;
using Lean.Common;
using Lean.Touch;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _tutorial;
    [SerializeField] private LeanPinchCamera _leanPinchCamera;
    [SerializeField] private GameObject _leanTouch;
    [SerializeField] private GameObject _FPSController;
    [SerializeField] private AudioSource _audioSource;
    
    public bool Transition;
    public float TransitionDuration = 3f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float initialNearClipPlane;
    private float transitionStartTime;


    private void Start()
    {
        initialPosition = _camera.transform.position;
        initialRotation = _camera.transform.rotation;
        initialNearClipPlane = _camera.nearClipPlane;
    }

    private void Update()
    {
        if (_leanPinchCamera.Zoom < 11f)
        {
            Transition = true;
            transitionStartTime = Time.time;
        }

        if (Transition)
        {
            float transitionProgress = (Time.time - transitionStartTime) / TransitionDuration;
            float smoothProgress = Mathf.SmoothStep(0f, 1f, transitionProgress);
            _camera.transform.position = Vector3.Lerp(initialPosition, _tutorial.position, smoothProgress);
            _camera.transform.rotation = Quaternion.Lerp(initialRotation, _tutorial.rotation, smoothProgress);
          
        }

        if (Vector3.Distance(_camera.transform.position, _tutorial.position) < 0.01f)
        {
                  _leanPinchCamera.enabled = false;
            _leanTouch.SetActive(false);
            Transition = false;
            this.enabled = false;
        }
    }

     private void OnDisable() {
         _FPSController.SetActive(true);
         _camera.transform.parent = _FPSController.transform;
         _camera.transform.localPosition = new Vector3(0, 0f, 0);
         _camera.transform.rotation= Quaternion.identity;
        _audioSource.Play();    
    }
}
