using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyBoost : MonoBehaviour
{

    Text timerText;
    Player player;

    void Start()
    {
        timerText = GameObject.FindGameObjectWithTag("boostTimer").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        player.moneyBoostTimer--;
        timerText.text = (player.moneyBoostTimer/60).ToString("#");
        if(player.moneyBoostTimer<=0){
            player.moneyBoostTimer=3600;
            player.boost-=10;
            Destroy(this.gameObject);
        }
    }

    

}
