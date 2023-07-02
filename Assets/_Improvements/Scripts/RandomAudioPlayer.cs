
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
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;

namespace AnimalFarm
{
    /// <summary>
    /// This class plays random audio clips from a list of audio sources.
    /// </summary>
    public class RandomAudioPlayer : MonoBehaviour
    {
        #region Public Members
         public int MaximumAnimal = 60;
        // This event is triggered when the maximum number of audio sources is reached.
        public UnityEvent MaxAudioSourcesReached;
        // The BPM of the audio clips.
        public float BPM = 127f;
        // The list of audio sources. That is dynamic - meaning that everytime that the player hits an animal 
        // one mor eaudiosource is added to the list 
        // you cannot do this with arrays - arrays are static
        public List<AudioSource> AudioSources = new List<AudioSource>();
        #endregion Public Members
        #region [SerializedField] Private Members
        [SerializeField]
        // a text that is updated with the count of animal that you got 
        private TextMeshProUGUI _animalCounter;
        [SerializeField]
        // we have a condition that decides if the game is infinite or not 
        private bool _infiniteGame = false;
        #endregion [SerializedField] Private Members
        #region Private Members
        // we have some private stuff that is needed for the audio to play and
        //calculate the delay between the audio clips based on the bpm 
        private float _delayBetweenAudio;
        private float _nextAudioTime;
        // this is the counter that is counting the animals 
        private int _counter = 0;
        #endregion Private Members
        #region Monobehaviour
        private void Start()
        {
            // you do not need these two lines of code because you have already set the text in the inspector
            // this prepares the audio to be played
            CalculateDelayBetweenAudio();
            // this calculates the time when the next audio will be played
            _nextAudioTime = Time.time;
            // time.time is the time since the game started and is automatically updated by unity 

    

            // bpm playing at a certain second 
            // bpm plays at 1 
            // 2 seconds 
            // 3 seconds
            // bpm plays at 4 

            // bpm needs to play every 3 seconds that is the difference between 4 and 1 
            // 4 - 1 = 

            /*
            EXAMPLE A 
            _nextAudioTime = 0;
            if (Time.time >= _nextAudioTime)
            {
                CalculateNextAudioTime();
            }
            EXAMPLE B 
            is the same as 
            _nextAudioTime = 0;
             if (6 >= 9)
            {
                // YOU NEED TO RECALCULATE THE NEXT TIME I CAN PLAY THE BPM AND WITH SO THE AUDIO 
                CalculateNextAudioTime();
            }
            */
            
        }

        private void Update()
        {
            // play a random audio clip if the time is right
            // this part gets the audio sources in the list and play them based on the bpm 
            // AudioSources.Count is the number of audio sources in the list
            // if you at least have one audio source in the list play it 
            // everytime that you run into an animal you add the sound to the list to be played 
            if (Time.time >= _nextAudioTime && AudioSources.Count > 0)
            {
                PlayRandomAudio();
                CalculateNextAudioTime();
            }
            // this part instead keeps track of the audio sources in the list and remove them if they are too many
            // or ends the game if we decide to have a finite game 
            // keep removing audio sources from the list if it gets too big
            if (AudioSources.Count > MaximumAnimal)
            {
                if (_infiniteGame)
                {
                    AudioSources.RemoveAt(0);
                    // removing the very first element of the list so we can add a new one and 
                    // the game keeps going
                }
                else
                {
                    MaxAudioSourcesReached.Invoke();
                    // this is the event that is triggered when the maximum number of audio sources is reached
                    // and we might call a methiod externally that shows the end game UI and stops this script from running 
                }
            }
        }
        #endregion Monobehaviour
        #region Public Methods

        public void AddSound(AudioSource audioSource)
        {
            AudioSources.Add(audioSource);
            _counter++;
            _animalCounter.text = _counter.ToString();
        }
        #endregion Public Methods
        #region Private Methods
        // Calculate the delay between audio clips based on the BPM.
        private void CalculateDelayBetweenAudio()
        {
            float secondsPerBeat = 60f / BPM;
            _delayBetweenAudio = secondsPerBeat;
        }

        private void CalculateNextAudioTime()
        {
            _nextAudioTime = Time.time + _delayBetweenAudio;
        }
        // audio is randomized for now but if you want we can maintain the order 
        private void PlayRandomAudio()
        {
            int randomIndex = Random.Range(0, AudioSources.Count);
            AudioSource randomAudioSource = AudioSources[randomIndex];
            foreach (AudioSource audioSource in AudioSources)
            {
                audioSource.Stop();
            }
            randomAudioSource.Play();
        }
        #endregion Private Methods
    }
}
