using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyEnemy : MonoBehaviour
{
    //public GameObject Player;
    //public Rigidbody rbPlayer;
    //PlayerMove playerMove;

    //private void Start()
    //{
    //  playerMove = 
    //}

    private void OnCollisionEnter(Collision collision)
    {
       // playerMove = collision.gameObject.GetComponent<PlayerMove>();
        if (collision.gameObject.CompareTag("Player"))// && rbPlayer.velocity.y !< 0f)

        {
            collision.transform.position = Manager3d.lastCheckPoint;
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Death, transform.position, 1f);
            Manager3d.AddLives(-1);

        }
    }
}
