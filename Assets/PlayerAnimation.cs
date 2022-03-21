using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] PlayerMove playerMoveScript;
    [SerializeField] private Animator anim;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ControlAnimations();

    }
    void ControlAnimations()
    {


        if (playerMoveScript.MoveVector.x != 0f || playerMoveScript.MoveVector.z != 0f)
        {
            anim.SetBool("IsRunning", true);


        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (playerMoveScript.playerOnGround == true)
        {
            anim.SetBool("IsJumping", false);
        }

        else
        {
            anim.SetBool("IsJumping", true);


        }



    }
}
