using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedEvents : MonoBehaviour
{

    public GameObject fly;
    public GameObject worker;
    public Vector3 flySpawn;
    public Vector3 workerSpawn;
    Player player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        InvokeRepeating("spawnWorker",0f,10f);
        //InvokeRepeating("spawnFly", 2.0f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void spawnFly(){
        flySpawn = new Vector3(-10f,5f,0f);
        Instantiate(fly,flySpawn,Quaternion.identity);
    }

    void spawnWorker(){
         if(player.currentWorkers<player.maxWorkers){
             workerSpawn = new Vector3(6.5f,0,0);
            Instantiate(worker,workerSpawn,Quaternion.identity);
            player.currentWorkers++;
        }
    }
}
