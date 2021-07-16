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
        InvokeRepeating("spawnRe",0f,10f);
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnRe(){
        if(player.milestone1){
        for(int i = 0;i<player.frogInc;i++){
            spawnPosition = new Vector3(Random.Range(-3.6f,-3f),2.5f,0f);
            roll = Random.Range(1f,100f);
            numSteps = Mathf.Floor(roll/stepsize); //this just decides if its going to be a queen based on the chance
            if(numSteps*stepsize>player.queenFrogChance){
                Instantiate(frog,spawnPosition,Quaternion.identity);
        
            } else{
                Instantiate(queenFrog,spawnPosition,Quaternion.identity);    
            }
        }
        }
    }
    public void spawn(){

        for(int i = 0;i<player.frogInc;i++){
            spawnPosition = new Vector3(Random.Range(-3.6f,-3f),2.5f,0f);
            roll = Random.Range(1f,100f);
            numSteps = Mathf.Floor(roll/stepsize); //this just decides if its going to be a queen based on the chance
            if(numSteps*stepsize>player.queenFrogChance){
                Instantiate(frog,spawnPosition,Quaternion.identity);
        
            } else{
                Instantiate(queenFrog,spawnPosition,Quaternion.identity);    
            }
        }
    }
}
