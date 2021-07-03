using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopController : MonoBehaviour
{

    public Player player;
    public Button[] buttons = new Button[6];
    double[] items = {1.2,4,125,1000,300,1750};
    int[] itemAmt = {0,0,0,0,0,0};
    int[] itemLimit = {10,20,5,1,10,100};
    int[] reqUpgrades = {0,0,0,0,0,30};
    int totalUpgrades = 0;
    public Text[] descTexts = new Text[6];
    string[] descs = {"increase egg value by 5%","increase egg rate by 5%","DOUBLES egg value","increase frog/click by 2","gain passive frogs /s","gives .1% chance to spawn queenFrog"};
 
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
            itemFunc(j,items,itemLimit,itemAmt,buttons,descs,descTexts,totalUpgrades,reqUpgrades);
        }
    }

    public void item0U(){
        if(player.money>=items[0] && itemAmt[0]<itemLimit[0]){
            player.money-=items[0];
            player.eggRate*=1.05;
            items[0]*=2.855;
            itemAmt[0]++;
            totalUpgrades++;
        }
    }
    public void item1U(){
        if(player.money>=items[1]&&itemAmt[1]<itemLimit[1]){
            player.money-=items[1];
            player.eggValue*=1.03;
            items[1]*=2.955;
            itemAmt[1]++;
            totalUpgrades++;
        }
    }
    public void item2U(){
        if(player.money>=items[2]&&itemAmt[2]<itemLimit[2]){
            player.money-=items[2];
            player.eggValue*=2;
            items[2]*=50;
            itemAmt[2]++;
            totalUpgrades++;
        }
    }
    public void item3U(){
        if(player.money>=items[3]&&itemAmt[3]<itemLimit[3]){
            player.money-=items[3];
            player.frogInc+=2;
            itemAmt[3]++;
            totalUpgrades++;
        }
    }
    public void item4U(){
        if(player.money>=items[4]&&itemAmt[4]<itemLimit[4]){
            player.money-=items[4];
            items[4]*=5;
            itemAmt[4]++;
            player.fps = true;
            player.fpsRate = itemAmt[4];
            totalUpgrades++;
        }
    }
    public void item5U(){
        if(player.money>=items[5]&&itemAmt[5]<itemLimit[5]){
            player.money-=items[5];
            items[5]*=1.01;
            player.queenFrogChance +=.1;
            itemAmt[5]++;
            totalUpgrades++;
        }

    }
    void itemFunc(int _i,double[] _items,int[] _itemLimit,int[] _itemAmt,Button[] _buttons,string[] _descs,Text[] _descTexts,int _totalUpgrades,int[] _reqUpgrades){
        if(_itemAmt[_i]<_itemLimit[_i]){
            _buttons[_i].GetComponentInChildren<Text>().text="item "+_i+": " + shortener(_items[_i]);
        }else{
                    _buttons[_i].GetComponentInChildren<Text>().text="item "+_i+" : LIMIT";
        }
        if(player.money<_items[_i]||_itemAmt[_i]>=_itemLimit[_i]||reqUpgrades[_i]>totalUpgrades){
            _buttons[_i].interactable= false;
            _buttons[_i].GetComponentInChildren<Text>().color = Color.white;

        }else{
            _buttons[_i].interactable = true;
            _buttons[_i].GetComponentInChildren<Text>().color = Color.green;
        }
        string tempDesc = _descs[_i]+"("+_itemAmt[_i].ToString()+"/"+_itemLimit[_i].ToString()+")";
        _descTexts[_i].text = tempDesc;
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
