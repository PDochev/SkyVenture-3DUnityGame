using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    [SerializeField] float dropSpeed, riseSpeed,timeTakenToRiseBack;
    
    [SerializeField] bool flip;
    
    [SerializeField] Vector3 start, end;

    float lerpRotation, lerpRotation2;

    [SerializeField] ShrinkAbility shrunk;
    // Start is called before the first frame update
    void Start()
    {
        shrunk = shrunk.GetComponent<ShrinkAbility>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flip==true)
        {
            FlipBoard();
            Invoke("UnFlip", timeTakenToRiseBack);
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (shrunk.transformed == false)
        {
            
            if (collision.gameObject.tag == "Player")
            {
                flip = true;

            }
        }
        

        
    }

    

    void FlipBoard()
    {
        lerpRotation += dropSpeed * Time.deltaTime;

        gameObject.transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(end), lerpRotation);

        lerpRotation2 = 0;
    }

    void UnFlip()
    {
        flip=false;
        lerpRotation2 += riseSpeed * Time.deltaTime;

        gameObject.transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(start), lerpRotation2);

        lerpRotation = 0;
    }
}
