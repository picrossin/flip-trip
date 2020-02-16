using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class TogglePlatform : MonoBehaviour
{

    public bool enabled = true;
    public Button button;
    public Sprite enabledSprite;
    public Sprite disabledSprite;

    BoxCollider2D collider;
    SpriteRenderer renderer;
    ShadowCaster2D shadows;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        shadows = GetComponent<ShadowCaster2D>();
    }

    void Update()
    {
        enabled = !button.pressed;
        if (enabled)
        {
            shadows.enabled = true;
            collider.enabled = true;
            renderer.sprite = enabledSprite;
        }
        else
        {
            shadows.enabled = false;
            collider.enabled = false;
            renderer.sprite = disabledSprite;
        }
    }
}
