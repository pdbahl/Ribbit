using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class saveData : MonoBehaviour
{
    Player player;
    string json;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        InvokeRepeating("saveJsonDataNoReset",10f,20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit(){
      //  Debug.Log(System.DateTime.Now.ToOADate());
     player.exitDate = System.DateTime.Now.ToOADate();
        saveJsonData();
    }
    public void saveJsonData(){
        player.currentMultiplyer=1;
        player.currentWorkers=0;
        player.boost = 1;
        json = JsonUtility.ToJson(player);//serialize json
        //Debug.Log(json);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);//write json to file
        print("data saved");
    }
     public void saveJsonDataNoReset(){
        json = JsonUtility.ToJson(player);//serialize json
        System.IO.File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);//write json to file
        //print("datasaved no reset)");
        Debug.Log(json);
    }

   

}


