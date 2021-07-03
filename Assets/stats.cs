using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour
{
    public Text stat;
    public Player player; 
    double cpf; 
    // Start is called before the first frame update
    void Start()
    {
        stat = GameObject.FindGameObjectWithTag("stats").GetComponent<Text>(); 
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        cpf = player.eggRate*player.eggValue*player.frogs;
        player.money += cpf;
        stat.text = "Cash: "+ shortener(player.money) +"\n frogs: "+ shortener(player.frogs)+"\n cash/sec " + shortener((cpf*60));
    }

    public string shortener(double a){
        if (a>=100000&&a<=999999){
            return (a*.001).ToString("#.##")+"K";
        }else if (a>=1000000&&a<1000000000){
            return (a*.000001).ToString("#.##")+"M";
        }else if (a>=1000000000&&a<1000000000000){
            return (a*.000000001).ToString("#.##")+"B";
        }

        return a.ToString("#.##");
    }
}
