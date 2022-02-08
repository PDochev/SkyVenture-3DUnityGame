using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp3D : MonoBehaviour
{

    public Manager3d.DoorKeyColour keyColour;

    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        if (keyColour==Manager3d.DoorKeyColour.Red)
        {
            rend.material.color = Color.red;

        }
        if (keyColour == Manager3d.DoorKeyColour.Yellow)
        {
            rend.material.color = Color.yellow;
        }
        if (keyColour == Manager3d.DoorKeyColour.Blue)
        {
            rend.material.color = Color.blue;
        }


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Manager3d.KeyPickUp(keyColour);

            Destroy(gameObject);


        }
    }
}