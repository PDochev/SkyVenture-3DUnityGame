using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int starsValue = 1;
    public int rotateSpeed;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {

            Manager3d.AddStars(starsValue);
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Star, transform.position, 0.5f);
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
