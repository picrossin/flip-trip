using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public int bodyPart = 0;
    public List<Sprite> partSprites = new List<Sprite>();

    SpriteRenderer renderer;
    float speed = 50f;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        speed = Random.Range(10f, 20f);
        GetComponent<Rigidbody2D>().velocity = Random.onUnitSphere * speed;

        renderer.sprite = partSprites[bodyPart];
    }
}
