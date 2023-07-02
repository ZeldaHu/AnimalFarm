
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
using UnityEngine;

namespace AnimalFarm
{
    /// <summary>
    /// This script is used to enable play canvas after audio clip is played.
    /// </summary>
    public class EnablePlayCanvas : MonoBehaviour
    {
        #region  [SerializeField] Private Members
        [SerializeField] private GameObject _playCanvas;
        [SerializeField] private AudioSource _audioSource;
        #endregion  [SerializeField] Private Members
        #region  Monobehaviour
        private void OnEnable()
        {
            // when this gameobject is enabled 
            // this game object waits untile the farmer finishes to talk 
            // and then set the canvas to active after that 
            // the farmer audiou clip is played and has a certain length 
            // so you wait those seconds _audioSource.clip.length
            StartCoroutine(Wait());
        }
        #endregion  Monobehaviour
        // a coroutine is a function that can suspend its execution (yield) until the given YieldInstruction finishes.
        // in other words you execute a method after a certain amount of time that you decide 
        #region  Coroutines
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(_audioSource.clip.length);
            // this is a function for waiting for a certain amount of time 
            // yield in english means to wait 
            // WaitForSeconds is a class that inherits from YieldInstruction
            // you are only going to see this structure in coroutines 
            _playCanvas.SetActive(true);
        }
         #endregion  Coroutines
    }

    // regions are used to organize the code 
    // you can collapse them and expand them
    // it is a good practice to use them

    // the monobehaviour in unity includes a lot of methods that are called automatically
    // usually chronologically this is the execution of things 
    // Awake() -> Start() -> Update() -> FixedUpdate() -> LateUpdate() -> OnGUI() -> OnDisable()

    // OnEnable() is called when the object becomes enabled and active.
    // Awake() is called when the script instance is being loaded.
    // Start() is called before the first frame update only if the script instance is enabled.
    // Update() is called every frame, if the script instance is enabled.
    // FixedUpdate() is called every fixed framerate frame, if the script instance is enabled.
    // LateUpdate() is called every frame, if the Behaviour is enabled.
    // OnGUI() is called for rendering and handling GUI events.
    // OnDisable() is called when the behaviour becomes disabled () or inactive.

}
