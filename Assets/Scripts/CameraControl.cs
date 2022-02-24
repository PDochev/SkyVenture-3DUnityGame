using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;

    //pivot is imaginary object which is placed at the same place as the character to prevent the player flip when using the camera to rotate on x axis 
    public Transform pivot;

    public float maxViewAngle;
    public float minViewAngle;

    public bool invertY;
        

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    //Late update happens after Update , every frame of animation before it moves to the next frame after update has happend , calls LateUpdate . After the player has moved , then Late Update is called
    void LateUpdate()
    {
        if (!Manager3d.gamePaused)
        {
            /*float yStore = rb.velocity.y;
        rb.velocity = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        rb.velocity = rb.velocity.normalized * speed;
        rb.velocity = new Vector3(rb.velocity.x, yStore, rb.velocity.z); */

            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;


            //get the x pos of the mouse
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.Rotate(0, horizontal, 0);

            //Get the Y position of the mouse and rotate the pivot

            float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
            //pivot.Rotate(-vertical, 0, 0);

            if (invertY)
            {
                pivot.Rotate(vertical, 0, 0);
            }
            else
            {
                pivot.Rotate(-vertical, 0, 0);
            }


            //Limit the up/down camera rotation
            if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
            {
                pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
            }

            if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
            {
                pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
            }

            //Move the camera based on the current rotation of the player
            float yAngle = target.eulerAngles.y;
            float xAngle = pivot.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);

            transform.position = target.position - (rotation * offset);

            //Lock the camera so it doesn't look under the floor

            if (transform.position.y < target.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
            }


            // transform.position = target.position - offset;
            transform.LookAt(target);
        }

        else
        {
            Cursor.visible = true;
        }
        
    }
}
