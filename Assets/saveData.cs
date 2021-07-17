using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        saveJsonData();
    }
    public void saveJsonData(){
        player.currentMultiplyer=1;
        player.currentWorkers=0;
        json = JsonUtility.ToJson(player);//serialize json
        System.IO.File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);//write json to file
    }
     public void saveJsonDataNoReset(){
        json = JsonUtility.ToJson(player);//serialize json
        System.IO.File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);//write json to file
    }

}
