using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool hasPower = false;
    public float rotateSpeed;
    public int timeUsed;

    [SerializeField] GameObject leftShoe, rightShoe;


   public void Start()
    {
        hasPower = false;
        //timeUsed = 0;

        leftShoe.active = false;
        rightShoe.active = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            hasPower = true;
            leftShoe.active = true;
            rightShoe.active = true;
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Power, transform.position, 0.5f);

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
