using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool hasPower = false;
    public float rotateSpeed;
    public int timeUsed;

    [SerializeField] GameObject rightBoot, leftBoot;
   public void Start()
    {
        hasPower = false;
        //timeUsed = 0;
        rightBoot.SetActive(false);
        leftBoot.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            hasPower = true;
            rightBoot.SetActive(true);
            leftBoot.SetActive(true);
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
