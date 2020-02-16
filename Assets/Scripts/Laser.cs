using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public bool isDiode = false;
    public bool vertical = false;
    public LayerMask collisionMask;
    public LayerMask laserEndCollisionMask;
    public LayerMask laserCollisionMask;
    public GameObject laserCollision;
    public GameObject laserPiece;

    GameObject laserCollisionInstance;
    Vector2 laserDir = Vector2.right;
    Flip flip;
    SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        flip = GameObject.FindObjectOfType(typeof(Flip)) as Flip;

        if (vertical)
            laserDir = Vector2.down;
        if (isDiode)
        {
            laserCollisionInstance = Instantiate(laserCollision, transform.position + new Vector3(0, 0, 3), transform.rotation);
            laserCollisionInstance.transform.parent = gameObject.transform.parent;
        }
    }

    void Update()
    { 
        if (flip.flipping && !isDiode)
        {
            Destroy(gameObject);
        }
        if (flip.flipped)
        {
            if (laserDir == Vector2.right)
            {
                laserDir = Vector2.left;
            }
            if (laserDir == Vector2.down)
            {
                laserDir = Vector2.up;
            }
        }

        if (!flip.flipping)
        {
            if (isDiode)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, laserDir, Mathf.Infinity, collisionMask);
                if (hit)
                {
                    if (vertical)
                    {
                        if (flip.flipped)
                        {
                            laserCollisionInstance.transform.position = hit.point - new Vector2(0f, .5f);
                        }
                        else
                        {
                            laserCollisionInstance.transform.position = hit.point + new Vector2(0f, .5f);
                        }
                    }
                    else
                    {
                        if (flip.flipped)
                        {
                            laserCollisionInstance.transform.position = hit.point + new Vector2(.5f, 0f);
                        }
                        else
                        {
                            laserCollisionInstance.transform.position = hit.point - new Vector2(.5f, 0f);
                        }
                    }
                    laserCollisionInstance.transform.position = new Vector3(laserCollisionInstance.transform.position.x, laserCollisionInstance.transform.position.y, 3);
                }
                RaycastHit2D laserEndHit = Physics2D.Raycast(transform.position, laserDir, .6f, laserEndCollisionMask);
                RaycastHit2D laserHit = Physics2D.Raycast(transform.position + new Vector3(laserDir.x * 0.6f, laserDir.y * 0.6f, 0), laserDir, .6f, laserCollisionMask);
                Debug.DrawRay(transform.position + new Vector3(laserDir.x * 0.6f, laserDir.y * 0.6f, 0), laserDir * 0.6f, Color.red);

                if (!laserEndHit && !laserHit)
                {
                    GameObject newLaser = Instantiate(laserPiece, transform.position + new Vector3(laserDir.x / 2, laserDir.y / 2, 0), transform.rotation);
                    newLaser.GetComponent<Laser>().vertical = vertical;
                    newLaser.transform.parent = gameObject.transform.parent;
                }
            }
            else
            {
                GameObject endLaser = GameObject.Find("/Level/Laser Impact(Clone)");

                RaycastHit2D laserHit = Physics2D.Raycast(transform.position + new Vector3(laserDir.x * 0.6f, laserDir.y * 0.6f, 0), laserDir, .6f, laserCollisionMask);

                if (flip.flipped)
                {
                    if (!laserHit && endLaser != null && ((!vertical && transform.position.x - 1f > endLaser.transform.position.x) || (vertical && transform.position.y + 1f < endLaser.transform.position.y)))
                    {
                        GameObject newLaser = Instantiate(laserPiece, transform.position + new Vector3(laserDir.x / 2, laserDir.y / 2, 0), transform.rotation);
                        newLaser.GetComponent<Laser>().vertical = vertical;
                        newLaser.transform.parent = gameObject.transform.parent;
                    }

                    if (endLaser != null && ((!vertical && transform.position.x < endLaser.transform.position.x) || (vertical && transform.position.y > endLaser.transform.position.y)))
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (!laserHit && endLaser != null && ((!vertical && transform.position.x + 1f < endLaser.transform.position.x) || (vertical && transform.position.y - 1f > endLaser.transform.position.y)))
                    {
                        GameObject newLaser = Instantiate(laserPiece, transform.position + new Vector3(laserDir.x / 2, laserDir.y / 2, 0), transform.rotation);
                        newLaser.GetComponent<Laser>().vertical = vertical;
                        newLaser.transform.parent = gameObject.transform.parent;
                    }

                    if (endLaser != null && ((!vertical && transform.position.x > endLaser.transform.position.x) || (vertical && transform.position.y < endLaser.transform.position.y)))
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
