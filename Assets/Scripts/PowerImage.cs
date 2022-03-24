using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerImage : MonoBehaviour
{
    public GameObject powerImage;


    //private void Start()
    //{
    //    powerImage.SetActive(false);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            powerImage.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            powerImage.SetActive(true);
        }
    }
}
