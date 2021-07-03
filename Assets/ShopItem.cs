using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    
    public double price;
    public string title;
    string displayText = "";
    
    void Start(){
        displayText = "title - " + price.ToString("#.##");

    }

}
