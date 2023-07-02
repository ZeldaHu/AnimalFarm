using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BPM : MonoBehaviour
{
    private static BPM _BPMInstance;
    public static float _bpm = 120;
    private float _beatInterval, _beatTimer;
    public static bool _beatFull;
    public static int _beatCountFull;

    public Slider bpmSlider;
    public TextMeshProUGUI bpmText;

    private void Awake()
    {
        if (_BPMInstance != null && _BPMInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _BPMInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        BeatDetection();

        //use slider to change to change bpm value
        _bpm = bpmSlider.value;
        bpmText.text = _bpm.ToString("0");
        //Debug.Log(_bpm);

    }

    void BeatDetection()
    {
        //full beat count
        _beatFull = false;
        _beatInterval = 60 / _bpm;
        _beatTimer += Time.deltaTime;

        if (_beatTimer >= _beatInterval)
        {
            _beatTimer -= _beatInterval;
            _beatFull = true;
            _beatCountFull++;
        }
    }
}
