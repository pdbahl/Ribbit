using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class loadData : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        string fileContents = File.ReadAllText(Application.persistentDataPath+"/playerData.json");

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
        JsonUtility.FromJsonOverwrite(fileContents,player);
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }
    
}
