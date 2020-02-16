using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public AudioClip upTrack;

    AudioManager am;

    void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }

    public void NextScene()
    {
        am.ChangeBGM(upTrack);
        SceneManager.LoadScene("Level 1");
    }
}
