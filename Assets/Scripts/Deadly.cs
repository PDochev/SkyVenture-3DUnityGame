using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag ==("Player"))
        {
            collision.transform.position = Manager3d.lastCheckPoint;
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Manager3d.AddLives(-1);

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = Manager3d.lastCheckPoint;
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            Manager3d.AddLives(-1);
        }
    }
}
