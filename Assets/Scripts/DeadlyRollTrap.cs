using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyRollTrap : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "RollTrap")
        {
            Destroy(gameObject);
        }
    }

}
