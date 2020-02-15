using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
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
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().freezeRotation = rotationLocked;
            RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right, .6f, collisionMask);
            RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.left, .6f, collisionMask);
            RaycastHit2D grounded = Physics2D.Raycast(transform.position, Vector2.down, .6f, collisionMask);

            nearWall = leftHit || rightHit;
            if (grounded && GetComponent<Rigidbody2D>().velocity.y < .1f)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Round(2 * transform.position.y) / 2, transform.position.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
