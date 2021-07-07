using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopController : MonoBehaviour
{

    public Player player;
    public Button[] buttons = new Button[20];
    double[] items = {1.2,4,125,1000,300,
                    1750,10500,150000,1234567,9876543,
                    666666,6969696,1200000,10000000,1500000,
                    21219909999,5000700000,23322622222,16665444332,67787667678}; //item base prices

    int[] itemAmt = {0,0,0,0,0,
                    0,0,0,0,0,
                    0,0,0,0,0,
                    0,0,0,0,0}; //amount of times upgraded

    int[] itemLimit = {10,20,5,2,10,
                    100,20,5,50,5,
                    10,1,15,10,10,
                    3,5,10,1,10};//the max amount an item can be upgraded

    int[] reqUpgrades = {0,0,0,0,0,
                        30,30,30,30,30,
                        100,100,100,100,100,
                        200,200,200,200,200};//the min amount of total upgrades you need for an item to be purchaseable

    int totalUpgrades = 0;
    public double priceReduction = 0;
    public Text[] descTexts = new Text[20];
    string[] descs = {  " increase egg value by 5%"," increase egg rate by 5%"," DOUBLES egg value",
                        " increase frog/click by 2"," gain passive frogs /s"," gives .1% chance to spawn queenFrog"
                        ,"reduces shop costs by .15%/rank","increase egg value and rate by 25% each",
                        "increase max multiplier by .5 per rank","increase bonus/frog/rank by .01",
                        "increase egg value by 10%/rank","increase frog/click by 5/rank","increase egg value by 5%/rank","descrese frog speed","increase passive frog/sec",
                        "increase workers by 1/rank","decrease work time by 5%","increase worker speed","increase rarity of worker gains","increase worker gains by 1%/rank"};
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
        if(buttonFunc(0,2.677)){
            player.eggRate*=1.05;
        }
    }
    public void item1U(){
        if(buttonFunc(1,1.567)){
            player.eggValue*=1.05;
        }
    }
    public void item2U(){
       if(buttonFunc(2,25)){
           player.eggValue*=2;
       }
    }
    public void item3U(){
       if(buttonFunc(3,100)){
            player.frogInc+=2;
       }
    }
    public void item4U(){
        if(buttonFunc(4,2.8)){
            player.fps = true;
            player.fpsRate = itemAmt[4];
        }
    }
    public void item5U(){
        if(buttonFunc(5,1.23)){
            player.queenFrogChance +=.1;
        }
    }
     public void item6U(){
        if(buttonFunc(6,1.6)){
            priceReduction+=.15;
        }
    }
     public void item7U(){
        if(buttonFunc(7,4.4444)){
            player.eggRate*=1.25;
            player.eggValue*=1.25;
        }
    }
     public void item8U(){
        if(buttonFunc(8,1.22)){
            player.maxMultiplyer+=0.5;   
        }
    } 
    public void item9U(){
        if(buttonFunc(9,1.788)){
            player.bonusPerFrog+=.01;
        }
    }
   public void item10U(){
        if(buttonFunc(10,2.1)){
            player.eggRate*=1.1;
        }
   }
    public void item11U(){
        if(buttonFunc(11,1)){
            player.frogInc+=5;

        }
    }
    public void item12U(){
        if(buttonFunc(12,2.1)){
            player.eggValue*=1.05;
        }
    }
    public void item13U(){
        if(buttonFunc(13,1)){
            player.speedInc*=.95f;
        }
    }
    public void item14U(){
        if(buttonFunc(14,2)){
            player.fpsRate*=1.5;
        }
    }
    public void item15U(){
        if(buttonFunc(15,3.543)){
            player.maxWorkers++;
        }
    }
    public void item16U(){
        if(buttonFunc(16,3.55)){
            player.workerTimer=(Mathf.FloorToInt(player.workerTimer*.95f));
        }
    }
    public void item17U(){
        if(buttonFunc(17,5)){
        player.workerSpeed *=1.2f;
        }
    }
    public void item18U(){
        if(buttonFunc(18,1)){

        }
    }
    public void item19U(){
        if(buttonFunc(19,2)){
            player.workerGainPercent+=.01;
        }
    }
   //functionality of the buttons, changes colors and if theyre interactable
    void itemFunc(int _i){
        if(itemAmt[_i]<itemLimit[_i]){
            buttons[_i].GetComponentInChildren<Text>().text="item "+_i+": " + shortener(items[_i]*(1-(priceReduction)*.01));
        }else{
                    buttons[_i].GetComponentInChildren<Text>().text="item "+_i+" : LIMIT";
        }
        if(player.money<items[_i]*(1-(priceReduction)*.01)||itemAmt[_i]>=itemLimit[_i]||reqUpgrades[_i]>totalUpgrades){
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
    bool buttonFunc(int id,double priceInc){
        if(player.money>=items[id]*(1-(priceReduction)*.01)&&itemAmt[id]<itemLimit[id]){
            player.money-=items[id]*(1-(priceReduction)*.01);
            items[id]*=priceInc;
            itemAmt[id]++;
            totalUpgrades++;
            return true;
        }
        return false;
    }
}
