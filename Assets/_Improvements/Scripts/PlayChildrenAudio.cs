using System.Collections;
using UnityEngine;

public class PlayChildrenAudio : MonoBehaviour
{

    public GameObject [] visualFeedback;
    private void Start()
    {
        StartCoroutine(PlayChildrenAudioSequentially());
    }


    private IEnumerator PlayChildrenAudioSequentially()
    {
          foreach (GameObject visualFeedback in visualFeedback)
        {
            visualFeedback.SetActive(false);
        }
        AudioSource[] childAudioSources = GetComponentsInChildren<AudioSource>();
        int randomIndex = Random.Range(0, childAudioSources.Length);

        childAudioSources[randomIndex].Play();
        visualFeedback[randomIndex].SetActive(true);
    
       yield return new WaitForSeconds(1);

         StartCoroutine(PlayChildrenAudioSequentially());
    }

}
