using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public bool flipping = false;
    public bool flipped = false;
    public GameObject level;
    public float smooth = 1f;

    BoxCollider2D collider;
    SpriteRenderer renderer;
    Quaternion targetRotation;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (flipping)
        {
            if (level.transform.rotation != targetRotation)
            {
                if (Mathf.Abs(level.transform.rotation.z) < 0.99f)
                {
                    level.transform.rotation = Quaternion.Slerp(level.transform.rotation, targetRotation, smooth * Time.deltaTime);
                }
                else
                {
                    level.transform.rotation = Quaternion.RotateTowards(level.transform.rotation, targetRotation, 30 * Time.deltaTime);
                }
            }
            else
            {
                flipped = true;
                flipping = false;
                renderer.enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            flipping = true;
            collider.enabled = false;
            targetRotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
