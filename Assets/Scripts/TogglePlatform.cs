using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlatform : MonoBehaviour
{

    public bool enabled = true;
    public Button button;
    public Sprite enabledSprite;
    public Sprite disabledSprite;

    BoxCollider2D collider;
    SpriteRenderer renderer;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        enabled = !button.pressed;
        if (enabled)
        {
            collider.enabled = true;
            renderer.sprite = enabledSprite;
        }
        else
        {
            collider.enabled = false;
            renderer.sprite = disabledSprite;
        }
    }
}
