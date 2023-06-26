using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInstruction : MonoBehaviour
{

    Canvas instructionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        instructionCanvas = GameObject.Find("GameScene_OpenInstruction").GetComponent<Canvas>();
        instructionCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            instructionCanvas.enabled = true;
        }
    }
}
