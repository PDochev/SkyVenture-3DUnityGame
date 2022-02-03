using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float movementSpeed;
    public float jump;
    private Vector3 moveDirection;
    public float gravityScale;

    public bool playerOnGround = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            playerOnGround = true;
        }
    }



    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        //moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * movementSpeed;


        if (Input.GetButtonDown("Jump") && playerOnGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
            playerOnGround = false;
        }


        //float yStore = moveDirection.y;

        //moveDirection.y = yStore;

        //moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        //rb.MovePosition(moveDirection * Time.deltaTime);


    }
}
