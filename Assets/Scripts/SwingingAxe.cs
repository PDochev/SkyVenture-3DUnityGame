using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxe : MonoBehaviour
{

    public bool changeDirection;
    
    public float speedOfSwing;
    
    float lerpRotation, lerpRotation2;
   
    [SerializeField] Vector3 start, end;
    public void Start()
    {

       
        
    }


    void Update()
    {
        if (lerpRotation >= speedOfSwing)
        {
            changeDirection = false;

        }

        if (lerpRotation2>=speedOfSwing)
        {
            changeDirection = true;

        }


        if (changeDirection==true)
        {
            
            lerpRotation += speedOfSwing * Time.deltaTime;
            
            gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(end), lerpRotation);

            lerpRotation2 = 0;
        }

        if (changeDirection == false)
        {
            lerpRotation2 += speedOfSwing * Time.deltaTime;
            
            gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(start), lerpRotation2);

            lerpRotation = 0;

        }

    }

}
