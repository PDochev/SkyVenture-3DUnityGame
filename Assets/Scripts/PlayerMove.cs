   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 playerMovement;

    public Vector3 MoveVector;


    public Rigidbody rb;
    
    [SerializeField] private float speed, fallMultiplier, jump,dashSpeed,floatStrength;
    
    public LayerMask enemyLayer;

    public PowerUp powerUp;


    public FloatPower floatPower;

    //public DoubleJump doubleJump;

    public float JumpPadForce;

    private  const int maxJump = 2; // this sets how many jumps we want for our player (currently 2 , so we can double jump) 

    private int currentJump = 0;

    public bool hasJumpingAbility;

    public bool playerOnGround = true;

    bool powerActivated;

    public AudioManager am;
    float sinceLastFootsteps;
    float timeBetwenFootsteps = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Manager3d.lastCheckPoint = transform.position;
        
        powerUp = powerUp.GetComponent<PowerUp>();

        //doubleJump = doubleJump.GetComponent<DoubleJump>();
        floatPower = floatPower.GetComponent<FloatPower>();

        am = FindObjectOfType<AudioManager>();




        //powerUp.timeUsed = 100;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingPlatform")
        {
            playerOnGround = true;
            currentJump = 0;

        }

        if (collision.gameObject.tag == "MovingPlatform")// this collision detects whether the player is colliding with a moving platform, if it is, it will make the player a child object of the moving platform so that the player moves together with the platform, instead of just falling off~~Karahan
        {
             gameObject.transform.parent = collision.gameObject.transform;
            
            //however the player must then detach from its new parent object, so a "OnCollisionExit" has been used below to detach the player from the moving platform when it is no longer in contact with it~~Karahan

        }

        if (collision.gameObject.tag == "JumpPad")
        {
            rb.AddForce(0, JumpPadForce, 0,ForceMode.Impulse);
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Bounce, transform.position, 1f);
        }

        //if (collision.gameObject.tag == "Enemy" && rb.velocity.y < 0f && playerOnGround == false) //&& jump < 0f && playerOnGround == false && collision.gameObject != null)
        //{
        //    collision.gameObject.GetComponent<EnemyAI>().TakeDamage(2);

        //}


        if (collision.gameObject.tag == "EnemyTop")
        {
            //collision.gameObject.GetComponent<EnemyAI>().TakeDamage(2);
            //Manager3d.AddLives(1);
            rb.AddForce(0, 5f, 0, ForceMode.Impulse);
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

    public void FixedUpdate()
    {
        if (rb.velocity.y < 0) //this checks whether the players rb y velocity is less than 0, if it is it would meaan the player is falling, which could also mean the player is falling after jump ~~Karahan
            
            // this if statement is what allows the player to have a better jump, by increasing the gravity on its "Vector3.y" when it is falling so it comes back down more quickly after jumping, instead of hovering around ~~ Karahan
        {
            if (floatPower.currentlyFloating==true && floatPower.hasFloatPower == true) //this if statement is checking the FloatPower script to see whether the player is activating and whether the player has the power up
            {
                rb.velocity += Vector3.up * Physics.gravity.y * Time.deltaTime * 0.00001f ; //here it is slowing the speed of gravity increasing by multiplying by 0.00001

                rb.AddForce(6, floatStrength, 0);  //to also give the effect of hovering/floating a bit of force is being added on the players y position, to try stop it from falling down straight away


                if (rb.velocity.y < -8) //here it is checking if the vector of the rigidbody is falling down too quickly 
                {
                    rb.velocity=new Vector3(0,-2,0); //when the rigidbodies vector y is below -10, that means it is fallin gpretty quickly, so if is this if statement checks that and resets the vector y to -2, to stop it building up speed and going below -10.
                }
                Debug.Log(rb.velocity.y);

                
            }

            else //this else statement is what triggers the players normal fall, so if the player is not activating float power and is does not have the float ability do the code above, ELSE trigger this normal falling speed.
            {
                rb.velocity += Vector3.up * Physics.gravity.y * Time.deltaTime * fallMultiplier;
                if(rb.velocity.y < -35)
                {
                    rb.velocity = new Vector3(0, -20, 0);
                }
                
            }
            
        }
    }
   

    public void MovePlayer()
    {
        MoveVector = transform.TransformDirection(playerMovement) * speed;
        rb.velocity = new Vector3(MoveVector.x, rb.velocity.y, MoveVector.z);





        if (Input.GetButtonDown("Jump") && (playerOnGround || maxJump > currentJump) && hasJumpingAbility == true) // if our max jump is > 0 , then increment the current jump;
        {


            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
            playerOnGround = false;
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Jump, transform.position, 1f);
            currentJump++;
        }

        if (Input.GetButtonDown("Jump") && playerOnGround && hasJumpingAbility == false) // if our max jump is > 0 , then increment the current jump;
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
            playerOnGround = false;
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Jump, transform.position, 1f);
           
        }


        if (Input.GetKey(KeyCode.Q) && powerUp.hasPower == true)
        {

            rb.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
            //FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Dash, transform.position, 1f);
            /*powerUp.timeUsed--;
            print(powerUp.timeUsed);


            if (powerUp.timeUsed <= 0)
            {
                powerUp.hasPower = false;

            }
            */

        }

        sinceLastFootsteps += Time.deltaTime;
        if(MoveVector.x != 0f && playerOnGround == true)
        {
            if(sinceLastFootsteps > timeBetwenFootsteps)
            {
                sinceLastFootsteps = 0f;
                am.AudioTrigger(AudioManager.SoundFXCat.FootStepGrass, transform.position, 1f);
            }
        }

        //if(playerOnGround && rb.velocity.y >= 0f)
        //{
           
        //        am.AudioTrigger(AudioManager.SoundFXCat.HitGround, transform.position, 1f);
           
        //}





        /*
        if (Input.GetKeyDown(KeyCode.Q) && powerUp.hasPower == true)
        {
            //activate powr = true

            powerActivated = true;

            rb.AddForce(transform.forward * 5f, ForceMode.Impulse);
             powerUp.hasPower = false;

              powerUp.timeUsed--;
              print(powerUp.timeUsed);


              if (powerUp.timeUsed <= 0)
              {
        powerUp.hasPower = false;
        }

        }

         if(activate power)
        if (powerActivated == true)
        {

              rb.AddForce(transform.forward * 5f, ForceMode.Impulse);
            powerUp.timeUsed--;
           print(powerUp.timeUsed);


            if (powerUp.timeUsed <= 0)
            {
                powerUp.hasPower = false;
                powerActivated = false;


            }
        } */

        

    }

    

    


}
