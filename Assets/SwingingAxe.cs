using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxe : MonoBehaviour
{

    bool changeDirection,changeDirection2,isRotating;
    public float speedOfSwing;
    float lerpRotation, lerpRotation2;
    public float angle1;
    public float angle2;
    float b;
    [SerializeField] Vector3 start, end;
    public void Start()
    {

        

        /*while (a < 90)
        {
            b = Time.deltaTime *speedOfSwing;
            transform.rotation = Quaternion.Euler(b,0,0);
            ++a;
        }*/

        
    }


    void Update()
    {
        /*if (gameObject.transform.localEulerAngles.x >= 88)
        {

            changeDirection = true;

        }

        else if (gameObject.transform.localEulerAngles.x <= 88)
        {

            changeDirection = false;
        
        }*/


        if (changeDirection==true)
        {
            
            lerpRotation = speedOfSwing * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Lerp(Quaternion.Euler(end), Quaternion.Euler(start), lerpRotation);
            lerpRotation2 = 0;

            if (gameObject.transform.localEulerAngles.x == 90)
            {

                changeDirection = false;
            }
        }

        if (changeDirection == false)
        {
            lerpRotation2 = speedOfSwing * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Lerp(Quaternion.Euler(start), Quaternion.Euler(end), lerpRotation2);
            lerpRotation = 0;

            if (gameObject.transform.localEulerAngles.x == 90)
            {
                changeDirection = true;
            }
        }

    }

    public void ReachedFirstPoint()
    {
        
    }
}
