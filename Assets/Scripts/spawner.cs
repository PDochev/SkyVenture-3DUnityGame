using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject spikyLog;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLog", 0f, 3f);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnLog()
    {
        Instantiate(spikyLog,transform.position,transform.rotation);
    }


}
