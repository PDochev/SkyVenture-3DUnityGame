using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int starsValue = 1;
   


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {

            Manager3d.AddStars(starsValue);
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Star, transform.position, 0.5f);
            Destroy(gameObject);
        }
    }

    
}
