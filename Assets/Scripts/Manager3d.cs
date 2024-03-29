using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Manager3d : MonoBehaviour
{
    public static Manager3d instance;
    public static int coins , lives , stars;

    public enum DoorKeyColour { Red, Blue, Yellow };//these store the values of red blue and yellow and are variables

    public static bool redKey, blueKey, yellowKey; //these store whether the corresponding keys have been picked up or not
    
    public static Vector3 lastCheckPoint;
    public static bool gamePaused;

    static GameUI gameUI;
    


    


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

        gameUI = FindObjectOfType<GameUI>();
        lives = 3;
        coins = 0;
        stars = 0;
        gameUI.UpdateCoins();
        gameUI.UpdateLives();
        redKey = false;
        blueKey = false;
        yellowKey = false;

        //access new function in GameUi;     
    }

    public static void AddCoins(int coinValue)
    {
        coins += coinValue;
        if(coins >= 100)
        {
            coins -= 100;
            AddLives(1);
        }
        gameUI.UpdateCoins();
    }

    public static void AddStars(int starsValue)
    {
        stars += starsValue;
        //print(stars);
        if(stars == 10)
        {

            // gameUI.CheckGameState(GameUI.GameState.GameOver);
            
             Application.LoadLevel("MainMenu");
            //SceneManager.LoadScene("MainMenu");
            
;

        }
        else
        {
            gameUI.UpdateStars();
        }

    }

    

    public static void AddLives(int lifeValue)
    {
        lives += lifeValue;
        if(lifeValue == -1)
        {
            //FindObjectOfType<AudioManager>().AudioTrigger(AudioManager.SoundFXCat.Death, Vector3.zero, 1f);

        }
        if (lives < 0)
        {
            gameUI.CheckGameState(GameUI.GameState.GameOver);
        }
        else
        {
            gameUI.UpdateLives();
        }

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

        gameUI.UpdateKeys(keyColour);

        print(keyColour + "key has been picked up");
    }

    
}
