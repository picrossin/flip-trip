using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShaderSwitch : MonoBehaviour
{
    public Material upShader;
    public Material downShader;

    Flip flip;
    TilemapRenderer renderer;

    void Start()
    {
        flip = GameObject.FindObjectOfType(typeof(Flip)) as Flip;
        renderer = GetComponent<TilemapRenderer>();
    }

    void Update()
    {
        if (flip.flipped)
        {
            renderer.material = downShader;
        }
        else
        {
            renderer.material = upShader;
        }
    }
}
