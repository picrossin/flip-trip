using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Door : MonoBehaviour
{
    public AudioClip upTrack;
    public GameObject winSound;

    Flip flip;
    LevelLoader loader;
    SpriteRenderer renderer;
    Light2D light;
    AudioManager am;

    void Start()
    {
        loader = GameObject.FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
        flip = GameObject.FindObjectOfType(typeof(Flip)) as Flip;
        renderer = GetComponent<SpriteRenderer>();
        light = GetComponent<Light2D>();
        am = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (light != null)
        {
            if (flip.flipped)
            {
                renderer.color = Color.white;
                light.enabled = true;
            }
            else
            {
                light.enabled = false;
            }
        }

        if (Input.GetButtonDown("Skip"))
        {
            loader.LoadNextLevel();
            am.ChangeBGM(upTrack);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (flip.flipped && other.tag == "Player")
        {
            Instantiate(winSound, transform.position, transform.rotation);
            am.ChangeBGM(upTrack);
            other.GetComponent<Player>().transitioning = true;
            other.transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);
            loader.LoadNextLevel();
        }
    }
}
