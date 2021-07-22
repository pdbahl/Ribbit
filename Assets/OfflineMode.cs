using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class OfflineMode : MonoBehaviour
{
    Player player;
    Text offline;
    double secondsSince;
    public GameObject greeting;
    double moneyFromWorkers = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        greeting = GameObject.FindGameObjectWithTag("greeting");
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        offline = GameObject.FindGameObjectWithTag("offline").GetComponent<Text>();
        secondsSince = (System.DateTime.Now - DateTime.FromOADate(player.exitDate)).TotalSeconds;
        if (player.maxWorkers > 0&&secondsSince>(player.workerTimer/60)) {
            moneyFromWorkers = (9 * (secondsSince * (player.cpf * 60)))*.2;
            offline.text = "You were gone for "+ secondsSince.ToString("#")+" seconds and gained..." + (secondsSince * (player.fpsRate)).ToString("#")+
            " frogs and " + shortener(secondsSince *(player.cpf*60)) + " dollars\n Money from workers: " + moneyFromWorkers;
            player.money += moneyFromWorkers;
            player.totalMoney += moneyFromWorkers;
        }
        else{
            offline.text = "You were gone for "+ secondsSince.ToString("#")+" seconds and gained..." + (secondsSince * (player.fpsRate)).ToString("#")+
            " frogs and " + shortener(secondsSince *(player.cpf*60)) + " dollars";
        }
        
        player.frogs += (secondsSince * (player.fpsRate));
        Debug.Log(secondsSince + " " + player.fpsRate + " " + player.cpf);
        player.money += (secondsSince * (player.cpf*60));
        player.totalMoney += (secondsSince * (player.cpf*60));
        
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
    public string shortener(double a){
        if (a>=100000&&a<=999999){
            return (a*.001).ToString("#.##")+"K";
        }else if (a>=1000000&&a<1000000000){
            return (a*.000001).ToString("#.##")+"M";
        }else if (a>=1000000000&&a<1000000000000){
            return (a*.000000001).ToString("#.##")+"B";
        }else if (a>=1000000000000&&a<1000000000000000){
            return (a*.000000000001).ToString("#.##")+"T";
        }else if (a>=1000000000000000&&a<1000000000000000000){
            return (a*.000000000000001).ToString("#.##")+"q";
            
        }

        return a.ToString("#.##");
    }
}
