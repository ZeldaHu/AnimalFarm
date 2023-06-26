using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    Canvas instructionCanvas;
    Canvas introCanvas;

   private void Start()
    {
        //Initially, the main_Canvas is displayed first, and the info_Canvas is hidden
        instructionCanvas = GameObject.Find("InstructionCanvas").GetComponent<Canvas>();
        introCanvas = GameObject.Find("IntroCanvas").GetComponent<Canvas>();
        instructionCanvas.enabled = false;
        introCanvas.enabled = true;
    }

    // btn_backMainCanvas calls this function to change canvas to main_Canvas
    public void BackIntroCanvas()
    {
        instructionCanvas.enabled = false;
        introCanvas.enabled = true;
    }

    // btn_info calls this function to change canvas to info_Canvas
    public void InstructionCanvas()
    {
        instructionCanvas.enabled = true;
        introCanvas.enabled = false;

    }

    // btn_start calls this function to change scene to "GameScene"
    public void EnterGame(string SceneName)
    {
        SceneManager.LoadScene("GameScene");
    }
}
