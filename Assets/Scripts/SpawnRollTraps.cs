using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRollTraps : MonoBehaviour
{
    public GameObject rollTrap1;
    public GameObject rolltrap2;

    float spawnTimer = 0f;
    public float spawnDelay = 2f;

    float spawnXMin = 10f;
    float spawnXMax = -10f;
    //[SerializeField] float spawnHeight = 1f;


    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnDelay)
        {
            Spawn();
            spawnTimer = 0f;
        }
    }

    void Spawn()
    {
        //float spawnX = (Random.Range(spawnXMin, spawnXMax) );
        //print(spawnY);
       // int range = Random.Range(0, 6);
        GameObject ob;
        //if(range <= 3)
        //{
        //    ob = Instantiate(rollTrap1, transform.position + new Vector3(0f, 0f, spawnX), transform.rotation);
        //}
        //else if (range > 3 && range <= 6)
        //{
        //    ob = Instantiate(rolltrap2, transform.position + new Vector3(0f, 0f, spawnX), transform.rotation);
        //}
        // ob = Instantiate(rollTrap1, transform.position + new Vector3(0f, 0f, spawnX), transform.rotation);
         ob = Instantiate(rollTrap1, transform.position, transform.rotation);
        
    }
}
