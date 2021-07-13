using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workerAI : MonoBehaviour
{
    Player player;
    public Vector2 home;
    public Vector2 target;
    float step;
    public int timer;
    bool worked = false;
    public GameObject boostFly;
    void Start(){
        timer = 0;
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        home = this.transform.position;
        target = new Vector2(-8.6f,3);
    }  

    // Update is called once per frame
    void Update()
    {
        step = player.workerSpeed*Time.deltaTime;
        this.transform.position = Vector2.MoveTowards(transform.position,target,step);
        if(Vector2.Distance(transform.position,target)<.0001&&timer<player.workerTimer){
            timer++;
            
        }
        if(timer >=player.workerTimer){
        target = home;
        worked = true;
        }
        
        if(worked &&(Vector2.Distance(transform.position,target)<.001)){
            player.currentWorkers--;
            workerReward();
            Destroy(transform.root.gameObject);
        }
    }

    void workerReward(){
            float numSteps = Mathf.Floor(Random.Range(0f,100f)); //this just decides if its going to be a queen based on the chance
            if(numSteps<=player.boostChance){
                Instantiate(boostFly);
                player.boost=10;
            }else{
                player.money += (double)(Random.Range(.1f,(float)player.workerGainPercent)*(float)player.totalMoney);
                player.totalMoney+= player.workerGainPercent*player.totalMoney;
        }
    }

}
