using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnd : MonoBehaviour
{
    Flip flip;
    SpriteRenderer renderer;

    void Start()
    {
        flip = GameObject.FindObjectOfType(typeof(Flip)) as Flip;
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        renderer.enabled = !flip.flipping;
    }
}
