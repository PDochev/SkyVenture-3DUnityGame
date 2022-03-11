using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = Manager3d.lastCheckPoint;
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Death, transform.position, 1f);

            Manager3d.AddLives(-1);

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.position = Manager3d.lastCheckPoint;
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Death, transform.position, 1f);
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Manager3d.AddLives(-1);
        }
    }
}
