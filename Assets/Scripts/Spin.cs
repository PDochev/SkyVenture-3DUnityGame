using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float rotateZ=0.5f,rotateSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Manager3d.gamePaused)
        {
            transform.Rotate(0, rotateSpeed, rotateZ, Space.Self);
        }
           

    }
}
