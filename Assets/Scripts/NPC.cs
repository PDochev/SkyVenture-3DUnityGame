using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;

    //    private void OnCollisionEnter(Collision collision)
    //    {
    //        if (collision.gameObject.CompareTag("Player"))
    //        {

    //            dialoguePanel.SetActive(true);
    //        }
    //    }

    //    private void OnCollisionExit(Collision collision)
    //    {
    //        dialoguePanel.SetActive(false);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dialoguePanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dialoguePanel.SetActive(false);
        }
    }



    

}


