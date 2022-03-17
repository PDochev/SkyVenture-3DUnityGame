using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum SoundFXCat { FootStepGrass, FootStepWood, Jump, Death, HitGround, HitCeiling, Checkpoint, Squish, OpenDoor, PickupKey, PickupCoin, Power, Lives, Bounce, Shrink, Dash , Star}
    public GameObject audioObject;
    public AudioClip[] footSteps;
    public AudioClip[] ladderSteps;
    public AudioClip[] jumpAudio;
    public AudioClip[] deathAudio;
    public AudioClip[] groundedAudio;
    public AudioClip[] ceilingedAudio;
    public AudioClip[] checkpoint;
    public AudioClip[] squishAudio;
    public AudioClip[] openDoorAudio;
    public AudioClip[] keyClips;
    public AudioClip[] coinClips;
    public AudioClip[] power;
    public AudioClip[] lives;
    public AudioClip[] bounce;
    public AudioClip[] shrink;
    public AudioClip[] dash;
    public AudioClip[] star;



    public void AudioTrigger(SoundFXCat audioType, Vector3 audioPosition, float volume)
    {
        GameObject newAudio = GameObject.Instantiate(audioObject, audioPosition, Quaternion.identity);
        ControlAudio ca = newAudio.GetComponent<ControlAudio>();
        switch (audioType)
        {
            case (SoundFXCat.Death):
                ca.myClip = deathAudio[Random.Range(0, deathAudio.Length)];
                break;
            case (SoundFXCat.Checkpoint):
                ca.myClip = checkpoint[Random.Range(0, checkpoint.Length)];
                break;
            case (SoundFXCat.FootStepGrass):
                ca.myClip = footSteps[Random.Range(0, footSteps.Length)];
                break;
            case (SoundFXCat.FootStepWood):
                ca.myClip = ladderSteps[Random.Range(0, ladderSteps.Length)];
                break;
            case (SoundFXCat.HitCeiling):
                ca.myClip = ceilingedAudio[Random.Range(0, ceilingedAudio.Length)];
                break;
            case (SoundFXCat.HitGround):
                ca.myClip = groundedAudio[Random.Range(0, groundedAudio.Length)];
                break;
            case (SoundFXCat.Jump):
                ca.myClip = jumpAudio[Random.Range(0, jumpAudio.Length)];
                break;
            case (SoundFXCat.OpenDoor):
                ca.myClip = openDoorAudio[Random.Range(0, openDoorAudio.Length)];
                break;
            case (SoundFXCat.PickupCoin):
                ca.myClip = coinClips[Random.Range(0, coinClips.Length)];
                break;
            case (SoundFXCat.PickupKey):
                ca.myClip = keyClips[Random.Range(0, keyClips.Length)];
                break;
            case (SoundFXCat.Squish):
                ca.myClip = squishAudio[Random.Range(0, squishAudio.Length)];
                break;
            case (SoundFXCat.Power):
                ca.myClip = power[Random.Range(0, power.Length)];
                break;
            case (SoundFXCat.Lives):
                ca.myClip = lives[Random.Range(0, lives.Length)];
                break;
            case (SoundFXCat.Bounce):
                ca.myClip = bounce[Random.Range(0, bounce.Length)];
                break;
            case (SoundFXCat.Shrink):
                ca.myClip = shrink[Random.Range(0, shrink.Length)];
                break;
            case (SoundFXCat.Dash):
                ca.myClip = dash[Random.Range(0, dash.Length)];
                break;
            case (SoundFXCat.Star):
                ca.myClip = star[Random.Range(0, star.Length)];
                break;
        }
        ca.volume = volume;
        ca.StartAudio();
    }
}
