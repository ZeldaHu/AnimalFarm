using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public GameObject instructionCanvas;


    void Start()
    {
        instructionCanvas.SetActive(false);

    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Start))
        {
            instructionCanvas.SetActive(true);
        }

        else
        {
            instructionCanvas.SetActive(false);
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {
            SceneManager.LoadScene("GameScene");
            Debug.Log("RESTART");
        }

    }

    public void ReplayBtn()
    {
        SceneManager.LoadScene("IntroScene");
    }

}
