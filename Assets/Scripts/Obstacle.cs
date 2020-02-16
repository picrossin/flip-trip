using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject death;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Death previousDeath = GameObject.FindObjectOfType(typeof(Death)) as Death;
            if (previousDeath == null)
                Instantiate(death, transform.position, transform.rotation);
        }
    }
}
