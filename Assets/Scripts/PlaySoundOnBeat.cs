using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnBeat : MonoBehaviour
{
    public SoundManager _soundManager;

    public int noteNum = 16; // the number of all notes player can add;
    public int beatNum = 8; // 8 beats per track
    public AudioClip tapClip, tickClip; //reminding tempo click
    public AudioClip[] _notes = new AudioClip[16];
    public AudioClip cowClip, birdClip, dogClip, horseClip, llamaClip, pigClip, sheepClip, turkeyClip, cloudClip;

    public Sprite cowIcon, birdIcon, dogIcon, horseIcon, llamaIcon, pigIcon, sheepIcon, turkeyIcon, cloudIcon;
    public Image[] _beatIcons = new Image[16];

   // [SerializeField] private LayerMask previewLayer;
    public GameObject replayBtn, gameOverImg;

    private int colCounter = -1; // detect collision's number


    void Start()
    {
        noteNum = 16;
        beatNum = 8;
        colCounter = -1;

        _notes = new AudioClip[16];

        replayBtn.SetActive(false);
        gameOverImg.SetActive(false);

        //****The following code is wrong and will make array null****//

        //_beatIcons = new Image[8];

        //for (int i = 0; i < _beatIcons.Length; i++)
        //{
        //    _beatIcons[i] = GetComponent<Image>();
        //    Object.ReferenceEquals(_beatIcons[i], null);
        //}

       
    }

    void Update()
    {
        //using the remainder to trigger different events 

        if (BPM._beatFull && BPM._beatCountFull % beatNum == 1)
        {
            _soundManager.TempoSound(tapClip, 0.35f);// AudioClip clip, float volume
            _soundManager.PlayTrackOne(_notes[0], 1);
            _soundManager.PlayTrackTwo(_notes[8], 1);

            Debug.Log("note1");

        }
        if (BPM._beatFull && BPM._beatCountFull % beatNum == 2)
        {
            _soundManager.TempoSound(tickClip, 0.3f);
            _soundManager.PlayTrackOne(_notes[1], 1);
            _soundManager.PlayTrackTwo(_notes[9], 1);

            Debug.Log("note2");
        }
        if (BPM._beatFull && BPM._beatCountFull % beatNum == 3)
        {
            _soundManager.TempoSound(tickClip, 0.3f);
            _soundManager.PlayTrackOne(_notes[2], 1);
            _soundManager.PlayTrackTwo(_notes[10], 1);
            Debug.Log("note3");
        }
        if (BPM._beatFull && BPM._beatCountFull % beatNum == 4)
        {
            _soundManager.TempoSound(tickClip, 0.3f);
            _soundManager.PlayTrackOne(_notes[3], 1);
            _soundManager.PlayTrackTwo(_notes[11], 1);
            Debug.Log("note4");
        }
        if (BPM._beatFull && BPM._beatCountFull % beatNum == 5)
        {
            _soundManager.TempoSound(tapClip, 0.35f);
            _soundManager.PlayTrackOne(_notes[4], 1);
            _soundManager.PlayTrackTwo(_notes[12], 1);
            Debug.Log("note5");
        }
        if (BPM._beatFull && BPM._beatCountFull % beatNum == 6)
        {
            _soundManager.TempoSound(tickClip, 0.3f);
            _soundManager.PlayTrackOne(_notes[5], 1);
            _soundManager.PlayTrackTwo(_notes[13], 1);
            Debug.Log("note6");
        }
        if (BPM._beatFull && BPM._beatCountFull % beatNum == 7)
        {
            _soundManager.TempoSound(tickClip, 0.3f);
            _soundManager.PlayTrackOne(_notes[6], 1);
            _soundManager.PlayTrackTwo(_notes[14], 1);
            Debug.Log("note7");
        }
        if (BPM._beatFull && BPM._beatCountFull % beatNum == 0)
        {
            _soundManager.TempoSound(tickClip, 0.3f);
            _soundManager.PlayTrackOne(_notes[7], 1);
            _soundManager.PlayTrackTwo(_notes[15], 1);
            Debug.Log("note8");
        }

        // after game the screen will be locked and pop up notification
        if (colCounter >= 15)
        {
            Debug.Log("GameOver");
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            replayBtn.SetActive(true);
            gameOverImg.SetActive(true);
        }

    }


    void OnCollisionEnter(Collision col)
    {
        Debug.Log("COL");
        // avoid to letting player to collide with ground at the beginning
        if (col.collider.tag == "cow" || col.collider.tag == "bird" || col.collider.tag == "dog" || col.collider.tag == "horse" || col.collider.tag == "llama" || 
            col.collider.tag == "pig" || col.collider.tag == "sheep" || col.collider.tag == "turkey" || col.collider.tag == "cloud")
        {
            colCounter++; 
        }

            for (int i = 0; i < noteNum; i++)
            {
                if (colCounter == i)
                {

                    Debug.Log("col:" + i);

                    if (col.gameObject.tag == "cow")
                    {
                        _notes[i] = cowClip;
                        _beatIcons[i].sprite = cowIcon;
                        col.gameObject.layer = LayerMask.NameToLayer("StarAnimal"); //change layer to avoid collidering again;
                    }
                    if (col.collider.tag == "bird")
                    {
                        _notes[i] = birdClip;
                        _beatIcons[i].sprite = birdIcon;
                        col.gameObject.layer = LayerMask.NameToLayer("StarAnimal");
                    }
                    if (col.collider.tag == "dog")
                    {
                        _notes[i] = dogClip;
                        _beatIcons[i].sprite = dogIcon;
                        col.gameObject.layer = LayerMask.NameToLayer("StarAnimal");

                    }
                    if (col.collider.tag == "horse")
                    {
                        _notes[i] = horseClip;
                        _beatIcons[i].sprite = horseIcon;
                        col.gameObject.layer = LayerMask.NameToLayer("StarAnimal");

                    }
                    if (col.collider.tag == "llama")
                    {
                        _notes[i] = llamaClip;
                        _beatIcons[i].sprite = llamaIcon;
                        col.gameObject.layer = LayerMask.NameToLayer("StarAnimal");
                    }
                    if (col.collider.tag == "pig")
                    {
                        _notes[i] = pigClip;
                        _beatIcons[i].sprite = pigIcon;
                        col.gameObject.layer = LayerMask.NameToLayer("StarAnimal");
                    }
                    if (col.collider.tag == "sheep")
                    {
                        _notes[i] = sheepClip;
                        _beatIcons[i].sprite = sheepIcon;
                        col.gameObject.layer = LayerMask.NameToLayer("StarAnimal");
                    }
                    if (col.collider.tag == "turkey")
                    {
                        _notes[i] = turkeyClip;
                        _beatIcons[i].sprite = turkeyIcon;
                        col.gameObject.layer = LayerMask.NameToLayer("StarAnimal");
                    }

                    if (col.collider.tag == "cloud")
                    {
                       _notes[i] = cloudClip;
                       _beatIcons[i].sprite = cloudIcon;
                       col.gameObject.layer = LayerMask.NameToLayer("StarAnimal");
                    }


            }

            
        }



       
    
    }

}
