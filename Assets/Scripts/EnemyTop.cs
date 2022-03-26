using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTop : MonoBehaviour
{
   

    //public PlayerMove playerMove;


    //public void Start()
    //{
    //    playerMove = playerMove.GetComponent<PlayerMove>();
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "Player")
    //    {
    //        foreach (Transform child in transform)
    //            child.gameObject.SetActive(false);
    //        Destroy(transform.parent.gameObject);
    //        Manager3d.AddCoins(5);

    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);
           
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Squish, transform.position, 0.2f);
            Destroy(transform.parent.gameObject);
            Manager3d.AddCoins(5);


        }
    }

    
}
