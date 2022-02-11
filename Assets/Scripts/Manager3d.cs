using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager3d : MonoBehaviour
{
    public static Manager3d instance;
    private static int coins;

    public enum DoorKeyColour { Red, Blue, Yellow };//these store the values of red blue and yellow and are variables

    public static bool redKey, blueKey, yellowKey; //these store whether the corresponding keys have been picked up or not
    public static Vector3 lastCheckPoint;
    public static bool gamePaused;

    public void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {

            Destroy(gameObject);
        }
    }

    public static void AddCoins(int coinValue)
    {
        coins += coinValue;
        print("Coins = " + coins);
    }



    public static void UpdateCheckpoints(GameObject post)
    {
        lastCheckPoint = post.transform.position;
        CheckPoint[] allCheckPoings = FindObjectsOfType<CheckPoint>();
       /* foreach (CheckPoint cp in allCheckPoings)
        {
            if(cp != post.GetComponent<CheckPoint>())
            {
                post.transform.position = Manager3d.lastCheckPoint;
            }
        }*/
    }
    public static void KeyPickUp(DoorKeyColour keyColour)
    {
        switch (keyColour)
        {
            case DoorKeyColour.Red://this is saying if door key colour is red
                redKey = true;     //and if it is the variable for it being picked up will be true
                break;
            case DoorKeyColour.Blue:
                blueKey = true;
                break;
            case DoorKeyColour.Yellow:
                yellowKey = true;
                break;

        }


        print(keyColour + "key has been picked up");
    }
}
