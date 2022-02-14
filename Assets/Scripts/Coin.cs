using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 5;
    public int rotateSpeed;


    private void OnTriggerEnter(Collider collision)
    {
     if(collision.tag == "Player")
        {

            Manager3d.AddCoins(coinValue);
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
