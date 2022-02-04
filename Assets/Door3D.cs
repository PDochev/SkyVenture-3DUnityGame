using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3D : MonoBehaviour
{
    public Manager3d.DoorKeyColour keyColour;



    GameObject doorLock;


    // Start is called before the first frame update
    void Start()
    {
        doorLock = transform.Find("Cube").gameObject;
        
        Renderer doorColour=doorLock.GetComponent<Renderer>();

        if (keyColour == Manager3d.DoorKeyColour.Red)
        {
            doorColour.material.color = Color.red;

        }
        if (keyColour == Manager3d.DoorKeyColour.Yellow)
        {
            doorColour.material.color = Color.yellow;
        }
        if (keyColour == Manager3d.DoorKeyColour.Blue)
        {
            doorColour.material.color = Color.blue;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && doorLock != null)
        {
            switch (keyColour)
            {
                case Manager3d.DoorKeyColour.Red:
                    if (Manager3d.redKey) Destroy(doorLock);
                    break;
                case Manager3d.DoorKeyColour.Blue:
                    if (Manager3d.blueKey) Destroy(doorLock);

                    break;
                case Manager3d.DoorKeyColour.Yellow:
                    if (Manager3d.yellowKey) Destroy(doorLock);

                    break;

            }
        }
    }
}