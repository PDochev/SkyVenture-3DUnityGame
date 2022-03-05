using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxe : MonoBehaviour
{

    public bool changeDirection;
    
    public float timeTakenToGoNextPosition,speedOfSwing;
    
    [SerializeField] float lerpRotation, lerpRotation2;
   
    [SerializeField] Vector3 start, end;
    
    void Update()
    {
        if (lerpRotation >= timeTakenToGoNextPosition)
        {
            changeDirection = false;

        }

        if (lerpRotation2>= timeTakenToGoNextPosition)
        {
            changeDirection = true;

        }


        if (changeDirection==true)
        {
            
            lerpRotation += speedOfSwing * Time.deltaTime;
            
            gameObject.transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(end), lerpRotation);

            lerpRotation2 = 0;
        }

        if (changeDirection == false)
        {
            lerpRotation2 += speedOfSwing * Time.deltaTime;
            
            gameObject.transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(start), lerpRotation2);

            lerpRotation = 0;

        }

    }

}
