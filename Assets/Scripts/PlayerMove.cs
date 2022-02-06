using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 playerMovement;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] float fallMultiplier;

    public bool playerOnGround = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Manager3d.lastCheckPoint = transform.position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingPlatform")
        {
            playerOnGround = true;
        }

        if (collision.gameObject.tag == "MovingPlatform")// this collision detects whether the player is colliding with a moving platform, if it is, it will make the player a child object of the moving platform so that the player moves together with the platform, instead of just falling off~~Karahan
        {
            gameObject.transform.parent = collision.gameObject.transform;
            //however the player must then detach from its new parent object, so a "OnCollisionExit" has been used below to detach the player from the moving platform when it is no longer in contact with it~~Karahan

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.parent = null;

        }
    }
    // Update is called once per frame
    void Update()
    {

        playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMovement = playerMovement.normalized * speed;
        MovePlayer();

    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0) //this checks whether the players rb y velocity is less than 0, if it is it would meaan the player is falling, which could also mean the player is falling after jump ~~Karahan
            
            // this if statement is what allows the player to have a better jump, by increasing the gravity on its "Vector3.y" when it is falling so it comes back down more quickly after jumping, instead of hovering around ~~ Karahan
        {
            rb.velocity += Vector3.up * Physics.gravity.y * Time.deltaTime * fallMultiplier;
        }
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(playerMovement) * speed;
        rb.velocity = new Vector3(MoveVector.x, rb.velocity.y, MoveVector.z);

        if (Input.GetButtonDown("Jump") && playerOnGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
            playerOnGround = false;
        }
    }
}
