using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    float speed = 50f;

    void Start()
    {
        speed = Random.Range(25f, 40f);
        GetComponent<Rigidbody2D>().velocity = Random.onUnitSphere * speed;
    }
}
