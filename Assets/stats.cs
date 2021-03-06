using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour
{
    public Text stat;
    public Player player; 
    // Start is called before the first frame update
    void Start()
    {
        stat = GameObject.FindGameObjectWithTag("stats").GetComponent<Text>(); 
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //cash per frame
        
        player.money += player.cpf;
        player.totalMoney += player.cpf;
        stat.text = "    Cash: "+ shortener(player.money) +"\n    frogs: "+ shortener(player.frogs)+"\n    cash/sec "
         + shortener((player.cpf*Application.targetFrameRate)) + "\n    currentMultiplyer: "+ player.currentMultiplyer.ToString("#.#")+
         "\n    total money: " + shortener(player.totalMoney);
    }
    //makes the numbers like 1,000,000 -> 1M for example
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
