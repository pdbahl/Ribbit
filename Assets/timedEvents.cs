using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedEvents : MonoBehaviour
{

    public GameObject fly;
    public Vector3 spawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnFly", 2.0f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnFly(){
        spawnPosition = new Vector3(-10f,5f,0f);
        Instantiate(fly,spawnPosition,Quaternion.identity);
    }
}
