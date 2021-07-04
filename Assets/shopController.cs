using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopController : MonoBehaviour
{

    public Player player;
    public Button[] buttons = new Button[10];
    double[] items = {1.2,4,125,1000,300,1750,10500,150000,12345678,987654321};
    int[] itemAmt = {0,0,0,0,0,0,0,0,0,0};
    int[] itemLimit = {10,20,5,1,10,100,20,1,1,1};
    int[] reqUpgrades = {0,0,0,0,0,30,30,30,30,30};
    int totalUpgrades = 0;
    double priceReduction = 0;
    public Text[] descTexts = new Text[10];
    string[] descs = {  " increase egg value by 5%"," increase egg rate by 5%"," DOUBLES egg value",
                        " increase frog/click by 2"," gain passive frogs /s"," gives .1% chance to spawn queenFrog\n"
                        ,"reduces shop costs by .1%/rank","increase frog walking speed","desc8","desc9"};
 
    // Start is called before the first frame update
    void Start()
    {
    player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
   
    for(int i = 0;i<buttons.Length;i++){
        buttons[i] = GameObject.FindGameObjectWithTag("item"+i.ToString()).GetComponent<Button>();
        descTexts[i]=GameObject.FindGameObjectWithTag("desc"+i.ToString()).GetComponent<Text>();
    }
    

    }

    // Update is called once per frame
    void Update()
    {
        for(int j = 0;j<buttons.Length;j++){
            itemFunc(j);
        }
    }

    public void item0U(){
        if(player.money>=items[0] && itemAmt[0]<itemLimit[0]){
            player.money-=items[0]*(1-(priceReduction*itemAmt[0])*.01);;
            player.eggRate*=1.05;
            items[0]*=2.855;
            itemAmt[0]++;
            totalUpgrades++;
        }
    }
    public void item1U(){
        if(player.money>=items[1]&&itemAmt[1]<itemLimit[1]){
            player.money-=items[1]*(1-(priceReduction*itemAmt[1])*.01);;
            player.eggValue*=1.03;
            items[1]*=2.955;
            itemAmt[1]++;
            totalUpgrades++;
        }
    }
    public void item2U(){
        if(player.money>=items[2]&&itemAmt[2]<itemLimit[2]){
            player.money-=items[2]*(1-(priceReduction*itemAmt[2])*.01);
            player.eggValue*=2;
            items[2]*=50;
            itemAmt[2]++;
            totalUpgrades++;
        }
    }
    public void item3U(){
        if(player.money>=items[3]&&itemAmt[3]<itemLimit[3]){
            player.money-=items[3]*(1-(priceReduction*itemAmt[3])*.01);;
            player.frogInc+=2;
            itemAmt[3]++;
            totalUpgrades++;
        }
    }
    public void item4U(){
        if(player.money>=items[4]&&itemAmt[4]<itemLimit[4]){
            player.money-=items[4]*(1-(priceReduction*itemAmt[4])*.01);;
            items[4]*=5;
            itemAmt[4]++;
            player.fps = true;
            player.fpsRate = itemAmt[4];
            totalUpgrades++;
        }
    }
    public void item5U(){
        if(player.money>=items[5]&&itemAmt[5]<itemLimit[5]){
            player.money-=items[5]*(1-(priceReduction*itemAmt[5])*.01);;
            items[5]*=1.01;
            player.queenFrogChance +=.1;
            itemAmt[5]++;
            totalUpgrades++;
        }
    }
     public void item6U(){
        if(player.money>=items[6]&&itemAmt[6]<itemLimit[6]){
            player.money-=items[6]*(1-(priceReduction)*.01);;
            priceReduction+=.1;
            itemAmt[6]++;
            items[6]*=1.6;
        }
    }
     public void item7U(){
        if(player.money>=items[7]&&itemAmt[7]<itemLimit[7]){
            player.money-=items[7]*(1-(priceReduction*itemAmt[7])*.01);
            player.speedInc++;
            itemAmt[7]++;
        }
    } public void item8U(){
        if(player.money>=items[8]&&itemAmt[8]<itemLimit[8]){
            player.money-=items[8]*(1-(priceReduction*itemAmt[8])*.01);;
        }
    } public void item9U(){
        if(player.money>=items[9]&&itemAmt[9]<itemLimit[9]){
            player.money-=items[9]*(1-(priceReduction*itemAmt[9])*.01);;
        }
    }
   
   
    void itemFunc(int _i){
        if(itemAmt[_i]<itemLimit[_i]){
            buttons[_i].GetComponentInChildren<Text>().text="item "+_i+": " + shortener(items[_i]*(1-(priceReduction)*.01));
        }else{
                    buttons[_i].GetComponentInChildren<Text>().text="item "+_i+" : LIMIT";
        }
        if(player.money<items[_i]||itemAmt[_i]>=itemLimit[_i]||reqUpgrades[_i]>totalUpgrades){
            buttons[_i].interactable= false;
            buttons[_i].GetComponentInChildren<Text>().color = Color.white;

        }else{
            buttons[_i].interactable = true;
            buttons[_i].GetComponentInChildren<Text>().color = Color.green;
        }
        string tempDesc = descs[_i]+"("+itemAmt[_i].ToString()+"/"+itemLimit[_i].ToString()+")";
        descTexts[_i].text = tempDesc;
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
