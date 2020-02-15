using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float waitTime;
    public GameObject bodyPart;

    LevelLoader loader;

    void Start()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bodyPart, transform.position + new Vector3(Random.Range(0, .3f), Random.Range(0, .3f), 0), Quaternion.Euler(Random.onUnitSphere));
        }
        yield return new WaitForSeconds(waitTime);
        loader = GameObject.FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
        loader.RestartLevel();
    }
}
