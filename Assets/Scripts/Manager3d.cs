using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager3d : MonoBehaviour
{
    public static Manager3d instance;
    private static int coins;
    

    public static Vector3 lastCheckPoint;

    public void OnAwake() {
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
}
