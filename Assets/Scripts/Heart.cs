using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    public int rotateSpeed;
   // public GameObject effect;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
           // Instantiate(effect, transform.position, Quaternion.identity);
            Manager3d.AddLives(1);
            Destroy(gameObject);
        }
    }



    private void Update()
    {
        if (!Manager3d.gamePaused)
        {
            transform.Rotate(0, rotateSpeed, 0, Space.World);
        }

    }
}
