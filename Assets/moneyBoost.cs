using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyBoost : MonoBehaviour
{

    float timer = 300;
    float displayText = 300;
    Text timerText;
    Player player;

    void Start()
    {
        StartCoroutine(SelfDestruct());
        timerText = GameObject.FindGameObjectWithTag("boostTimer").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        player.boost=10;
    }

    // Update is called once per frame
    void Update()
    {
        displayText -=Time.deltaTime;
        timerText.text = displayText.ToString("#");
        
    }

    IEnumerator SelfDestruct(){
        yield return new WaitForSeconds(timer);
        player.boost=1;
        Destroy(this.gameObject);
    }

}
