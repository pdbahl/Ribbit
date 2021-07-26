using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class OfflineMode : MonoBehaviour
{
    Player player;
    Text offline;
    Text disclaimerText;
    double secondsSince;
    public GameObject greeting;
    double moneyFromWorkers = 0;
    double passiveMoneyGain = 0;
    double passiveFrogGain = 0;
    //double nerf = .1;

    
    // Start is called before the first frame update
    void Start()
    {
        greeting = GameObject.FindGameObjectWithTag("greeting");
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        offline = GameObject.FindGameObjectWithTag("offline").GetComponent<Text>();
        disclaimerText = GameObject.FindGameObjectWithTag("disclaimer").GetComponent<Text>();
        secondsSince = (System.DateTime.Now - DateTime.FromOADate(player.exitDate)).TotalSeconds;
        if(secondsSince>player.maxOfflineTime*3600){
            secondsSince = player.maxOfflineTime * 3600;
            }
        passiveMoneyGain = (secondsSince * (player.cpf * 60));
        passiveFrogGain = (secondsSince * (player.fpsRate));
        print(passiveFrogGain + " " + passiveMoneyGain);
        if (player.maxWorkers > 0&&secondsSince>(player.workerTimer/60)) {
            moneyFromWorkers = (9 * (secondsSince * (player.cpf * 60)))*.1;
            offline.text = "You were gone for "+ (secondsSince/3600).ToString("#.##")+" hours and gained..." + player.shortener(passiveFrogGain)+
            " frogs and " + player.shortener(passiveMoneyGain) + " dollars\n Money from workers: " + player.shortener(moneyFromWorkers);
            player.money += moneyFromWorkers;
            player.totalMoney += moneyFromWorkers;
        }
        else{
            offline.text = "You were gone for "+ (secondsSince/3600).ToString("#.##")+" hours and gained..." + player.shortener(passiveFrogGain)+
            " frogs and " + player.shortener(passiveMoneyGain) + " dollars";
        }
        disclaimerText.text = "You can only offline for a maximum of " + player.maxOfflineTime + " hours.";
        player.frogs += passiveFrogGain;
        Debug.Log(secondsSince + " " + player.fpsRate + " " + player.cpf);
        player.money += passiveMoneyGain;
        player.totalMoney += passiveMoneyGain;
        
       // Debug.Log(System.DateTime.Now + " " + player.exitDate + " " +secondsSince);
        if (!System.IO.File.Exists(Application.persistentDataPath + "/playerData.json"))
        {
            greeting.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void closeGreeting() {
        greeting.SetActive(false);
    }
    
}
