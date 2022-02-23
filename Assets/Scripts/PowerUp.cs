using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool hasPower = false;
    public int rotateSpeed;


   public void Start()
    {
        hasPower = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" )
        {
            hasPower = true;
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
