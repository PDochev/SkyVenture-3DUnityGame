using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{

    
    public float rotateSpeed;
    public PlayerMove pm;


   

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
           
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Power, transform.position, 0.5f);
            pm.hasJumpingAbility = true;
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
