using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopController : MonoBehaviour
{

    public Player player;
    public Button[] buttons = new Button[25];
    public Text[] descTexts = new Text[25];
    string[] descs = {  " increase egg value by 5%"," increase egg rate by 5%"," DOUBLES egg value"," increase frog/click by 2"," gain passive frogs /s",
                        " gives .1% chance to spawn queenFrog","reduces shop costs by .15%/rank","increase egg value and rate by 25% each","increase max multiplier by .5/rank","increase bonus/frog/rank by .01",
                        "increase egg value by 10%/rank","increase frog/click by 5/rank","increase egg value by 5%/rank","descrese frog speed","increase passive frog/sec",
                        "increase workers by 1/rank","decrease work time by 5%","increase worker speed","chance to possible get a 10x money boost","increase worker gains by 1%/rank",
                        "TRIPLES egg value","increase passive frog/sec","gain 10% of your CURRENT frogs","increase max multiplier by .1/rank","unlock new worker location"};
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
        tUpgradesText.text = "Total Upgrades: " + player.totalUpgrades.ToString();
        checkMilestones();
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
            player.fpsRate = player.itemAmt[4];
        }
    }
    public void item5U(){
        if(buttonFunc(5,1.23)){
            player.queenFrogChance+=.1;
        }
    }
     public void item6U(){
        if(buttonFunc(6,1.6)){
            player.priceReduction+=.15;
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
            player.maxMultiplyer+=.5;   
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
        if(buttonFunc(13,1.223)){
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
        player.workerSpeed*=1.2f;
        }
    }
    public void item18U(){
        if(buttonFunc(18,4.5)){
            player.boostChance++;
        }
    }
    public void item19U(){
        if(buttonFunc(19,1.25)){
            player.workerGainPercent+=.01;
        }
    }
    public void item20U(){
        if(buttonFunc(20,1)){
            player.eggValue*=3;
        }
    }
    public void item21U(){
        if(buttonFunc(21,3.876)){
            player.fpsRate*=1.5;
        }
    }
    public void item22U(){
        if(buttonFunc(22,4)){
            player.frogs*=1.1;
        }
    }
    public void item23U(){
        if(buttonFunc(23,1.23)){
            player.maxMultiplyer+=.1;
        }
    }
    public void item24U(){
        if(buttonFunc(24,1)){

        }
    }
   //functionality of the buttons, changes colors and if theyre interactable
    void itemFunc(int _i){
        if(player.itemAmt[_i]<player.itemLimit[_i]){
            buttons[_i].GetComponentInChildren<Text>().text="item "+_i+": " + shortener(player.items[_i]*(1-(player.priceReduction)*.01));
        }else{
                    buttons[_i].GetComponentInChildren<Text>().text="item "+_i+" : LIMIT";
        }
        if(player.money<player.items[_i]*(1-(player.priceReduction)*.01)||player.itemAmt[_i]>=player.itemLimit[_i]||player.reqUpgrades[_i]>player.totalUpgrades){
            buttons[_i].interactable= false;
            buttons[_i].GetComponentInChildren<Text>().color = Color.white;

        }else{
            buttons[_i].interactable = true;
            buttons[_i].GetComponentInChildren<Text>().color = Color.green;
        }
        string tempDesc = descs[_i]+"("+player.itemAmt[_i].ToString()+"/"+player.itemLimit[_i].ToString()+")";
        descTexts[_i].text = tempDesc;
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
    bool buttonFunc(int id,double priceInc){
        if(player.money>=player.items[id]*(1-(player.priceReduction)*.01)&&player.itemAmt[id]<player.itemLimit[id]){
            player.money-=player.items[id]*(1-(player.priceReduction)*.01);
            player.items[id]*=priceInc;
            player.itemAmt[id]++;
            player.totalUpgrades++;
            return true;
        }
        return false;
    }
    void checkMilestones(){
        if(player.itemAmt[0]==player.itemLimit[0]&&player.itemAmt[1]==player.itemLimit[1]&&player.itemAmt[2]==player.itemLimit[2]&&
        player.itemAmt[3]==player.itemLimit[3]&&player.itemAmt[4]==player.itemLimit[4]){
            player.milestone1 = true;    
        }
    }
}
