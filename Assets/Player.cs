using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public double[] items = {1.2,4,125,1000,300,
                    1750,10500,150000,1234567,9876543,
                    666666,6969696,1200000,10000000,1500000,
                    21219909999,5000700000,23322622222,16665444332,67787667678,
                    19999900099999,5670300030330,92488660211132,2232300022112,1}; //item base prices
    public int[] itemAmt = {0,0,0,0,0,
                    0,0,0,0,0,
                    0,0,0,0,0,
                    0,0,0,0,0,
                    0,0,0,0,0}; //amount of times upgraded

    public int[] itemLimit = {10,20,5,2,10,
                    100,20,5,50,5,
                    10,1,15,10,10,
                    3,5,10,5,10,
                    1,10,2,100,1};//the max amount an item can be upgraded

    public int[] reqUpgrades = {0,0,0,0,0,
                        30,30,30,30,30,
                        100,100,100,100,100,
                        200,200,200,200,200,
                        250,250,250,250,250};//the min amount of total upgrades you need for an item to be purchaseable

    public int totalUpgrades = 0;
    public double priceReduction = 0;
    public double money = 0;
    public double frogs = 0;
    public double eggRate = .01;
    public double eggValue = .03;
    public int frogInc = 1;
    public bool fps = false;
    public double fpsRate = 0;
    public double queenFrogChance = 0;
    public double totalMoney = 0;
<<<<<<< Updated upstream
    public float speedInc = .5f;
=======
    public float speedInc = 0.5f;
>>>>>>> Stashed changes
    public double currentMultiplyer = 1.0;
    public double maxMultiplyer = 1;
    public double bonusPerFrog = .02;
    public int workerTimer = 18000;
    public int maxWorkers = 0;
    public int currentWorkers = 0;
    public float workerSpeed = .4f;
    public double workerGainPercent = .1;
    public double boost =1;
    public double boostChance =0;
    public bool milestone1 = false;
    public bool milestone2=false;
    public int moneyBoostTimer = 3600;
    public double cpf;
    public int queenFrogValue =100;
    private bool milestone2Rewarded = false; 
    void Start()
    {
        loadData();
        cpf = eggRate*eggValue*frogs*currentMultiplyer*boost;
        #if UNITY_WEBGL
            Debug.Log("WebGL");
            Application.targetFrameRate=0;
        #else
            Debug.Log("Any other platform");
            Application.targetFrameRate=60;
        #endif
        rewardMilestone2();
    }

    // Update is called once per frame
    void Update()
    {
        cpf = eggRate*eggValue*frogs*currentMultiplyer*boost;
     if(currentMultiplyer<1){currentMultiplyer=1.0;}    
        if(fps==true){
            frogs+=.005 * fpsRate;
        }

    }
    void loadData(){
        if (System.IO.File.Exists("myfile.txt"))
        {
            //do stuff

            string fileContents = File.ReadAllText(Application.persistentDataPath + "/playerData.json");

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            JsonUtility.FromJsonOverwrite(fileContents, this);
            print("data loaded.");
        }
        }
    public void addFrog() => frogs+=frogInc;
    private void rewardMilestone2(){
        if(!milestone2Rewarded){
            this.queenFrogValue = 150;
            this.fpsRate*=2;
            this.milestone2Rewarded=true;
        }
    }
}
