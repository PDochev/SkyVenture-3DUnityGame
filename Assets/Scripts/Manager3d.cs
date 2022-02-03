using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager3d : MonoBehaviour
{
    public static Manager3d instance;

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
}
