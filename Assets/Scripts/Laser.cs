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

    void Start()
    {
        if (vertical)
            laserDir = Vector2.down;
        if (isDiode)
            laserCollisionInstance = Instantiate(laserCollision, transform.position, transform.rotation);
    }

    void Update()
    {
        if (isDiode)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, laserDir, Mathf.Infinity, collisionMask);
            if (hit)
            {
                if (vertical)
                {
                    laserCollisionInstance.transform.position = hit.point - new Vector2(0f, .5f);
                }
                else
                {
                    laserCollisionInstance.transform.position = hit.point - new Vector2(.5f, 0f);
                }
            }
            RaycastHit2D laserEndHit = Physics2D.Raycast(transform.position, laserDir, .6f, laserEndCollisionMask);
            if (!laserEndHit)
            {
                Instantiate(laserPiece, transform.position + new Vector3(laserDir.x / 2, laserDir.y / 2, 0), transform.rotation);
            }
        } 
        else
        {
            GameObject endLaser = GameObject.Find("/Laser Impact(Clone)");

            RaycastHit2D laserHit = Physics2D.Raycast(transform.position + new Vector3(laserDir.x * 0.6f, laserDir.y * -0.6f, 0), laserDir, .6f, laserCollisionMask);
            if (endLaser != null)
            if (!laserHit && endLaser != null && ((!vertical && transform.position.x + 1f < endLaser.transform.position.x) || (vertical && transform.position.y - 1f > endLaser.transform.position.y)))
            {
                Instantiate(laserPiece, transform.position + new Vector3(laserDir.x / 2, laserDir.y / 2, 0), transform.rotation);
            }

            if (endLaser != null && ((!vertical && transform.position.x > endLaser.transform.position.x) || (vertical && transform.position.y < endLaser.transform.position.y)))
            {
                Destroy(gameObject);
            }
        }
    }
}
