using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameObject post;


    // Start is called before the first frame update
    void Start()
    {
        post = transform.Find("checkpoint").gameObject;
    }

     private void OnTriggerEnter(Collider collision)
    {
       if(collision.tag == "Player")
        {
            Manager3d.UpdateCheckpoints(gameObject);
        } 
    } 

   

    public void LowerPost()
    {
       
    }

}
