using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : MonoBehaviour
{
    public Player player;
    private Vector2 position;
    private Vector2 target;
    private Vector2 target2 ;
    private Vector2 target3 ;
    public float speed;
    bool isRunning;
    bool counted;

    void Start()
    {
        isRunning=true;
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        target = new Vector2(Random.Range(-3.5f,-2.5f),Random.Range(0f,-1.5f));
        target2 = new Vector2(Random.Range(.5f,1f),Random.Range(-2.25f,-3f));
        target3 = new Vector2(6f,Random.Range(-2f,-3f));
      position = gameObject.transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        //make sure that it doesn't add to the running multiplier if its at the max multiplier already
        if(isRunning&&player.currentMultiplyer<player.maxMultiplyer){
            counted = true;
            player.currentMultiplyer+=player.bonusPerFrog;
            isRunning=false;
        }
        speed = player.speedInc;
        float step = speed*Time.deltaTime;
        //go to node1
       transform.position = Vector2.MoveTowards(transform.position,target,step);
        
        //go to node2
        if(Vector2.Distance(transform.position,target)<.01){
            target = target2;
        }
        //go to final node
        if(Vector2.Distance(transform.position,target)<.001){
            target = target3;
        }
        
        
        if(Vector2.Distance(transform.position,target3)<0.1f){
            if(counted){
            player.currentMultiplyer-=player.bonusPerFrog;
            }
            Destroy(transform.root.gameObject);
            if(this.gameObject.name=="queenFrog(Clone)"){
                player.frogs+=player.queenFrogValue;
            }else{
                player.frogs++;
            }        
        }
    }

    public void spawnFrog(){
       
    }
}
