using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxe : MonoBehaviour
{

    bool reachedFirstPoint;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Rotate(0, 0, 0);
        //gameObject.transform.localEulerAngles.x
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedFirstPoint==false)
        {
            

            gameObject.transform.Rotate(Time.deltaTime*20,0,0);
            Debug.Log("above 90d");
        } 

        else if (reachedFirstPoint)
        {
            Debug.Log("First Point Reached");
        }
    }

    public void ReachedFirstPoint()
    {
        if (gameObject.transform.localEulerAngles.x >= 90)
        {
            reachedFirstPoint= true;

        }
        else
        {
            reachedFirstPoint= false;
        }
    }
}
