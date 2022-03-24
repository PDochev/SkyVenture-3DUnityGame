using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] GameObject firstPoint;
    [SerializeField] GameObject secondPoint;

    /*these two objects will be two empty game objects with transform attached to them, 
     * their positions will be used as point A and point B ~~Karahan*/

    Vector3 firstP;
    Vector3 secondP;

    //these Vector 3 variables will their their x,y,z positions ~~Karahan


    float lerpPosition;
    float lerpPosition2;

    // lerp values range from 1 to 0, so we will need one lerp variable to get from point A to B,
    // then the other lerp variable will be used to get from point B to A ~~Karahan


    bool destinationReached = true;
    [SerializeField] bool changeDirection;
    //this boolean will check if a point has been reached, once it has this boolean will used to indicate to change ~~Karahan


    [SerializeField] float moveSpeed, moveSpeed2;// this will be used to determine how fast the platforms will move by multiplying by the lerp values ~~Karahan

    private void Start()
    {


        firstP = firstPoint.transform.position;
        secondP = secondPoint.transform.position;

        //here two of the vector 3 varaibles are being asigned to point A & B 's positions ~~Karahan
        if (changeDirection == true)
        {
            gameObject.transform.position = firstP;

        }
        if (changeDirection == false)
        {
            gameObject.transform.position = secondP;

        }
        //to start of the chain reaction of the platform moving On start it will first start from point A ~~Karahan



    }

    private void Update()
    {
        if (gameObject.transform.position == firstP)
        {
            destinationReached = true;
        }
        else if (gameObject.transform.position == secondP)
        {
            destinationReached = false;
        }
        //these two if statements will toggle on and off the boolean value when one of the two destinations have been reached ~~Karahan


        if (destinationReached == true)
        {
            lerpPosition += Time.deltaTime * moveSpeed; //this "lerpPosition" is being increasing every second whilst destinationReached is == true, by multiplying the seconds gone past will allow us to make the platform travel faster or slower ~~Karahan

            gameObject.transform.position = Vector3.Lerp(firstP, secondP, lerpPosition); //here the gameobjects transform position, is being lerped from point "firstP" to point "secondP" at the rate of which the lerpPosition is increasing; ~~Karahan 

            lerpPosition2 = 0f; //the reason the lerp positions are being set to zero is because where the lerp is being used in the "Vector3 Lerp" method, it can only have a value from 0 to 1, if it was not reset to zero, as time goes on these variables will keep increasing increasing. ~~Karahan

            //So before the platform gets to the other point, the lerp of the path it will about to follow next will be set to zero so that with time it will increase from 0  ~~Karahan

        }


        else if (destinationReached == false)
        //this statement is only false when the platform has reached the second P, indicating it needs to change direction~~Karahan
        {
            lerpPosition2 += Time.deltaTime * moveSpeed2;

            gameObject.transform.position = Vector3.Lerp(secondP, firstP, lerpPosition2);


            lerpPosition = 0f;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(firstP, secondP);

    }
}
