using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerImage : MonoBehaviour
{
    public GameObject powerImage;


    // Start is called before the first frame update
    void Start()
    {
        powerImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            powerImage.SetActive(true);
        }
    }
}
