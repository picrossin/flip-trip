using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBox : MonoBehaviour
{
    public LayerMask collisionMask;
    public bool nearWall = false;
    public bool rotationLocked = true;
    Flip flip;

    void Start()
    {
        flip = GameObject.FindObjectOfType(typeof(Flip)) as Flip;
    }

    void Update()
    {
        if (flip.flipping)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().freezeRotation = rotationLocked;
        }
    }
}
