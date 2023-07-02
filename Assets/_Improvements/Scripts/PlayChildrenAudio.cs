
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
    /// This script is used to play audio sequentially.
    /// </summary>
    public class PlayChildrenAudio : MonoBehaviour
    {
        #region Public Members
        public GameObject[] VisualFeedback; 
        // The visual feedback to show when playing audio
        // Here we insert all of the heart images for the respective animals 
        // Be careful thought that the order of the images is the same as the order of the animals in the array
        // So if the first animal in the array is the pig, then the first image in the array should be the pig's heart image
        // the order of the prefabs is visible in the inspiector as this is the parent object of all the animals
        #endregion Public Members
        #region Monobehaviour
        private void Start()
        {
            StartCoroutine(PlayChildrenAudioSequentially());
        }
        #endregion Monobehaviour
        #region Coroutines
        private IEnumerator PlayChildrenAudioSequentially()
        {
            // first step is deactivating all of the visual feedback 
            foreach (GameObject visualFeedback in VisualFeedback)
            // VisualFeedback is the array of all the heart images that I declared above  public GameObject[] VisualFeedback; 
            // specifically for the structure named foreach - you need to reference a object of the array
            {
                visualFeedback.SetActive(false);
            }
            /* this is the same as the foreach loop above - it is just a different way of writing it
            for (int i = 0; i < VisualFeedback.Length; i++)
            {
                VisualFeedback[i].SetActive(false);
            }
            */
            // then you get a random one of the children audio sources and play it
            AudioSource[] childAudioSources = GetComponentsInChildren<AudioSource>();
            int randomIndex = Random.Range(0, childAudioSources.Length);
            // then youi play the audio source of that random index
            childAudioSources[randomIndex].Play();
            // then you activate the visual feedback of that random index
            VisualFeedback[randomIndex].SetActive(true);
            // every 1 second we restart the coroutine 
            yield return new WaitForSeconds(1);
            // this is a function for waiting for a certain amount of time
            // is recursively calling the same function 
            StartCoroutine(PlayChildrenAudioSequentially());
        }
        #endregion Coroutines

    }
}
