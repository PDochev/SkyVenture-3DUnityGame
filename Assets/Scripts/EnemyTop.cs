using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTop : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);
            Destroy(transform.parent.gameObject);
            Manager3d.AddCoins(5);
        }
    }
}
