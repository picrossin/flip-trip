using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Flip flip;
    LevelLoader loader;

    void Start()
    {
        loader = GameObject.FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
        flip = GameObject.FindObjectOfType(typeof(Flip)) as Flip;
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
