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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit(){
        saveTheData();
    }
    public void saveTheData(){
        json = JsonUtility.ToJson(player);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
    }
}
