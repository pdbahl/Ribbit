using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopController : MonoBehaviour
{

    public Player player;
    public Button[] buttons = new Button[15];
    double[] items = {1.2,4,125,1000,300,
                    1750,10500,150000,1234567,9876543,
                    666666,6969696,1200000,10000000,1500000}; //item base prices

    int[] itemAmt = {0,0,0,0,0,
                    0,0,0,0,0,
                    0,0,0,0,0}; //amount of times upgraded

    int[] itemLimit = {10,20,5,2,10,
                    100,20,1,50,5,
                    10,1,15,1,10};//the max amount an item can be upgraded

    int[] reqUpgrades = {0,0,0,0,0,
                        30,30,30,30,30,
                        100,100,100,100,100};//the min amount of total upgrades you need for an item to be purchaseable

    int totalUpgrades = 0;
    public double priceReduction = 0;
    public Text[] descTexts = new Text[15];
    string[] descs = {  " increase egg value by 5%"," increase egg rate by 5%"," DOUBLES egg value",
                        " increase frog/click by 2"," gain passive frogs /s"," gives .1% chance to spawn queenFrog"
                        ,"reduces shop costs by .15%/rank","increase frog walking speed","increase max multiplier by .5 per rank","increase bonus/frog/rank by .01",
                        "increase egg value by 10%/rank","increase frog/click by 5/rank","increase egg value by 5%/rank","descrese frog speed","increase passive frog/sec"};
    public Text tUpgradesText;
 
    // Start is called before the first frame update
    void Start()
    {
    player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
    tUpgradesText = GameObject.FindGameObjectWithTag("totalUpgrades").GetComponent<Text>();
    //retrieves and populates these arrays with the respective components
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
        tUpgradesText.text = "Total Upgrades: " + totalUpgrades.ToString();
    }
    //these are all each individual upgrade's functionality
    public void item0U(){
        if(player.money>=items[0] && itemAmt[0]<itemLimit[0]){
            player.money-=items[0]*(1-(priceReduction)*.01);;
            player.eggRate*=1.05;
            items[0]*=2.855;
            itemAmt[0]++;
            totalUpgrades++;
        }
    }
    public void item1U(){
        if(player.money>=items[1]&&itemAmt[1]<itemLimit[1]){
            player.money-=items[1]*(1-(priceReduction)*.01);;
            player.eggValue*=1.03;
            items[1]*=1.567;
            itemAmt[1]++;
            totalUpgrades++;
        }
    }
    public void item2U(){
        if(player.money>=items[2]&&itemAmt[2]<itemLimit[2]){
            player.money-=items[2]*(1-(priceReduction)*.01);
            player.eggValue*=2;
            items[2]*=25;
            itemAmt[2]++;
            totalUpgrades++;
        }
    }
    public void item3U(){
        if(player.money>=items[3]&&itemAmt[3]<itemLimit[3]){
            player.money-=items[3]*(1-(priceReduction)*.01);;
            player.frogInc+=2;
            items[3]*=100;
            itemAmt[3]++;
            totalUpgrades++;
        }
    }
    public void item4U(){
        if(player.money>=items[4]&&itemAmt[4]<itemLimit[4]){
            player.money-=items[4]*(1-(priceReduction)*.01);;
            items[4]*=2.8;
            itemAmt[4]++;
            player.fps = true;
            player.fpsRate = itemAmt[4];
            totalUpgrades++;
        }
    }
    public void item5U(){
        if(player.money>=items[5]&&itemAmt[5]<itemLimit[5]){
            player.money-=items[5]*(1-(priceReduction)*.01);;
            items[5]*=1.23;
            player.queenFrogChance +=.1;
            itemAmt[5]++;
            totalUpgrades++;
        }
    }
     public void item6U(){
        if(player.money>=items[6]&&itemAmt[6]<itemLimit[6]){
            player.money-=items[6]*(1-(priceReduction)*.01);;
            priceReduction+=.15;
            itemAmt[6]++;
            items[6]*=1.6;
            totalUpgrades++;

        }
    }
     public void item7U(){
        if(player.money>=items[7]&&itemAmt[7]<itemLimit[7]){
            player.money-=items[7]*(1-(priceReduction)*.01);
            player.speedInc++;
            itemAmt[7]++;
            totalUpgrades++;        
        }
    }
     public void item8U(){
        if(player.money>=items[8]&&itemAmt[8]<itemLimit[8]){
            player.money-=items[8]*(1-(priceReduction)*.01);
            items[8]*=1.1;
            player.maxMultiplyer+=0.5;            
            itemAmt[8]++;
            totalUpgrades++;
        }
    } 
    public void item9U(){
        if(player.money>=items[9]&&itemAmt[9]<itemLimit[9]){
            player.money-=items[9]*(1-(priceReduction)*.01);
            player.bonusPerFrog+=.01;
            itemAmt[9]++;
            totalUpgrades++;
        }
    }
   public void item10U(){
        if(player.money>=items[10]&&itemAmt[10]<itemLimit[10]){
            player.money-=items[10]*(1-(priceReduction)*.01);
            player.eggRate*=1.1;
            items[10]*=1.5;
            itemAmt[10]++;
            totalUpgrades++;
        }
    }
    public void item11U(){
        if(player.money>=items[11]&&itemAmt[11]<itemLimit[11]){
            player.money-=items[11]*(1-(priceReduction)*.01);
            player.frogInc+=5;
            itemAmt[11]++;
            totalUpgrades++;
        }
    }
    public void item12U(){
        if(player.money>=items[12]&&itemAmt[12]<itemLimit[12]){
            player.money-=items[12]*(1-(priceReduction)*.01);
            player.eggValue*=1.05;
            items[12]*=2.1;
            itemAmt[12]++;
            totalUpgrades++;
        }
    }
    public void item13U(){
        if(player.money>=items[13]&&itemAmt[13]<itemLimit[13]){
            player.money-=items[13]*(1-(priceReduction)*.01);
            player.speedInc--;
            itemAmt[13]++;
            totalUpgrades++;
        }
    }
    public void item14U(){
        if(player.money>=items[14]&&itemAmt[14]<itemLimit[14]){
            player.money-=items[14]*(1-(priceReduction)*.01);
            player.fpsRate++;
            items[14]*=2;
            itemAmt[14]++;
            totalUpgrades++;
        }
    }
   //functionality of the buttons, changes colors and if theyre interactable
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
