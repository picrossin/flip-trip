using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    public List<AudioClip> screams = new List<AudioClip>();

    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = screams[Random.Range(0, screams.Count)];
        source.Play();
    }
}
