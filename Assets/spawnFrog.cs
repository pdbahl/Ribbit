using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFrog : MonoBehaviour
{
    public GameObject frog;
    public GameObject queenFrog;
    public Vector3 spawnPosition;
    public Player player;
    float roll;
    float stepsize = .1f;
    float numSteps;
    void Start()
    {

     player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn(){

        spawnPosition = new Vector3(Random.Range(-3.6f,-3f),2.5f,0f);
        roll = Random.Range(1f,100f);
        numSteps = Mathf.Floor(roll/stepsize); //this just decides if its going to be a queen based on the chance
        if(numSteps*stepsize>player.queenFrogChance){
            for(int i = 0;i<player.frogInc;i++){
        Instantiate(frog,spawnPosition,Quaternion.identity);
            }
        } else{
        Instantiate(queenFrog,spawnPosition,Quaternion.identity);    
        }
    }
}
