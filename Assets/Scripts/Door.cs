using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Door : MonoBehaviour
{
    Flip flip;
    LevelLoader loader;
    SpriteRenderer renderer;
    Light2D light;

    void Start()
    {
        loader = GameObject.FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
        flip = GameObject.FindObjectOfType(typeof(Flip)) as Flip;
        renderer = GetComponent<SpriteRenderer>();
        light = GetComponent<Light2D>();
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (flip.flipped && other.tag == "Player")
        {
            other.GetComponent<Player>().transitioning = true;
            other.transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);
            loader.LoadNextLevel();
        }
    }
}
