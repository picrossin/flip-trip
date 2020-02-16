using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGM;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void ChangeBGM(AudioClip music)
    {
        float time = BGM.time;
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
        BGM.time = time;
    }
}
