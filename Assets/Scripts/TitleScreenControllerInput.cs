using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenControllerInput : MonoBehaviour
{
    public AudioClip upTrack;

    AudioManager am;

    void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            am.ChangeBGM(upTrack);
            SceneManager.LoadScene("Level 1");
        }
        if (Input.GetButtonDown("Submit"))
        {
            Application.Quit();
        }
    }
}
