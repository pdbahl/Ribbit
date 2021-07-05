using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public double money = 0;
    public double frogs = 1;
    public double eggRate = .02;
    public double eggValue = .03;
    public int frogInc = 1;
    public bool fps = false;
    public double fpsRate = 0;
    public double queenFrogChance = 0;
    public double totalMoney = 0;
    public float speedInc;
    public double currentMultiplyer = 1.0;
    public double maxMultiplyer = 1;
    public double bonusPerFrog = .02;

    void Start()
    {
        if(currentMultiplyer<1){currentMultiplyer=1.0;}
        speedInc=0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(fps==true){
            frogs+=.002 * fpsRate;
        }

    }

    public void addFrog() => frogs+=frogInc;
}
