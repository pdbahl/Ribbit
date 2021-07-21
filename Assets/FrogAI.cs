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
<<<<<<< Updated upstream
      position = gameObject.transform.position;  
      speed = .5f;
=======
      position = gameObject.transform.position;
        player.speedInc = .5f;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
      // Debug.Log(this.transform.position.x +" "+ this.transform.position.y+ " " + Time.deltaTime + " " + Application.targetFrameRate);
=======
       //Debug.Log(this.transform.position.x +" "+ this.transform.position.y);
>>>>>>> Stashed changes
        
        if(isRunning&&player.currentMultiplyer<player.maxMultiplyer){
            counted = true;
            player.currentMultiplyer+=player.bonusPerFrog;
            isRunning=false;
        }
<<<<<<< Updated upstream
        float step = speed*Time.deltaTime;
=======
        float step = player.speedInc*Time.deltaTime;
        Debug.Log("Step: " + step + " " + player.speedInc + " " + Time.deltaTime);
>>>>>>> Stashed changes
       transform.position = Vector2.MoveTowards(this.transform.position,target,step);
        
        if(Vector2.Distance(this.transform.position,target)<.01){
            target = target2;
        }
        if(Vector2.Distance(this.transform.position,target)<.001){
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
