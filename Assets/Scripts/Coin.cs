using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 5;


    private void OnTriggerEnter(Collider collision)
    {
     if(collision.tag == "Player")
        {

            Manager3d.AddCoins(coinValue);
            Destroy(gameObject);
        }   
    }
}
