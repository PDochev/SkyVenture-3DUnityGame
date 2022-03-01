using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    bool playerTrigger; //this is a boolean that will be used to check if the player has touched the platform 
  
    Vector3 shrink,grow; //these are two different vector 3 values which will be applied to the scale of the platform
                         

    float lerpShrink,lerpScale;

    public float shrinkingRate,growingRate; //these are float values will determine how fast the platform shrinks and grows in the lerp methods 

    void Start()
    {
        shrink = new Vector3(0.01f, 0.01f, 0.01f); // this vector 3 holds the values of the platforms shrunken state

        grow = new Vector3(1f, 1f, 1f); // this vector 3 holds the values of the platforms grown state

        //a lerp method will be used to lerp between these two values to give the effect of shrinking and growing 
    }

    // Update is called once per frame
    void Update()
    {
        Shrink();
        GrowBackNow(); //these two functions ar being called constantly 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerTrigger = true;
        }
    }

    void Shrink()
    {
        if (playerTrigger )
        {
            
            lerpShrink += Time.deltaTime * shrinkingRate;
            
            
            gameObject.transform.localScale = Vector3.Lerp(transform.localScale,shrink, lerpShrink);

            if(gameObject.transform.localScale.x<0.02 && gameObject.transform.localScale.z < 0.02 && gameObject.transform.localScale.y < 0.02)
            {
                lerpScale = 0;

                Debug.Log("platform Has shrunk");
                GrowBack();
                

            }

            ///Invoke("GrowBack", 4);
            ///gameObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        }
    }

    void GrowBack()
    {
        if (playerTrigger)
        {
            playerTrigger = false;

        }
        
    }

    void GrowBackNow()
    {
        if (!playerTrigger)
        {
            lerpScale += Time.deltaTime * growingRate;

            gameObject.transform.localScale = Vector3.Lerp(transform.localScale, grow, lerpScale);
            lerpShrink = 0;
        }
    }
}
