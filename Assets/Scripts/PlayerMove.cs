using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 playerMovement;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float jump;

    public bool playerOnGround = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerOnGround = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

        playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMovement = playerMovement.normalized * speed;
        MovePlayer();

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
