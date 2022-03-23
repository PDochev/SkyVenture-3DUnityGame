using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAbility : MonoBehaviour
{

    public bool hasShrinkPower ,transformed = false;

    [SerializeField] Vector3 shrinkSize, grownSize;

    float lerpPosition1, lerpPosition2;

    [SerializeField] float transformSpeed;

    [SerializeField] ParticleSystem particle;

    [SerializeField] GameObject shrinkPotion;

    // Start is called before the first frame update
    void Start()
    {
        transformed = false;

        shrinkPotion.active = false;

    }

    // Update is called once per frame
    void Update()
    {


        if (hasShrinkPower == true)
        {
            shrinkPotion.active = true; //this line of code enables the potion model that attached to the side of the player when the powerup is taken 

            PlayerShrinkAbility();
        }
    }

    void PlayerShrinkAbility()
    {
        

        if (Input.GetKeyDown(KeyCode.T) && hasShrinkPower)
        {

            transformed = !transformed;
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Shrink, transform.position, 0.6f);
            particle.Play();
        }

        if (transformed == true)
        {
            Shrink();
        }

        if (transformed != true)
        {
            Grow();
        }
    }

    private void Shrink()
    {
        //transform.localScale = new Vector3(shrinkSize, shrinkSize, shrinkSize);

        if (lerpPosition2 < 1)
        {
            lerpPosition2 += Time.deltaTime * transformSpeed;

            transform.localScale = Vector3.Lerp(grownSize, shrinkSize, lerpPosition2);
            
        }

        lerpPosition1 = 0;

    }

    private void Grow()
    {
        //transform.localScale = new Vector3(1, 1, 1);

        if (lerpPosition1 < 1)
        {
            lerpPosition1 += Time.deltaTime * transformSpeed;
            transform.localScale = Vector3.Lerp(shrinkSize, grownSize, lerpPosition1);
            
        }

        lerpPosition2 = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ShrinkPower")
        {
            hasShrinkPower = true;
            FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Power, transform.position, 0.5f);
            Destroy(collision.gameObject);
        }
    }
}
