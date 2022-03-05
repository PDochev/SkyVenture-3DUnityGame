using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPower : MonoBehaviour
{
    [SerializeField] public bool hasFloatPower,currentlyFloating;

    public void Start()
    {
        hasFloatPower = false;
        currentlyFloating = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E)  && hasFloatPower)
        {
            currentlyFloating = true;
        }
        
        
        if(Input.GetKeyUp(KeyCode.E) && hasFloatPower)
        {
            currentlyFloating = false;

        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FloatPower")
        {
            hasFloatPower = true;
            Destroy(collision.gameObject);

        }
    }
}
