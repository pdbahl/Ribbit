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
            player.money += player.workerGainPercent*player.totalMoney;
            print(player.workerGainPercent*player.totalMoney);
            player.totalMoney+= player.workerGainPercent*player.totalMoney;
            Destroy(transform.root.gameObject);
        }
        
    }

}
