using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float waitTime;
    public GameObject bodyPart;
    public GameObject explosionSound;
    public GameObject screamSound;
    public AudioClip upTrack;
    AudioManager am;

    LevelLoader loader;

    void Start()
    {
        am = FindObjectOfType<AudioManager>();
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        Instantiate(explosionSound, transform.position, transform.rotation);
        Instantiate(screamSound, transform.position, transform.rotation);

        for (int i = 0; i < 8; i++)
        {
            GameObject part = Instantiate(bodyPart, transform.position + new Vector3(Random.Range(0, .3f), Random.Range(0, .3f), 0), Quaternion.Euler(Random.onUnitSphere));
            part.GetComponent<BodyPart>().bodyPart = i;
        }
        yield return new WaitForSeconds(waitTime);
        am.ChangeBGM(upTrack);
        loader = GameObject.FindObjectOfType(typeof(LevelLoader)) as LevelLoader;
        loader.RestartLevel();
    }
}
