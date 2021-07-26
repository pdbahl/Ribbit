using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINav : MonoBehaviour
{
    
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject infoPanel;

    void Start()
    {
        panel1 = GameObject.FindGameObjectWithTag("panel1");
        panel2 = GameObject.FindGameObjectWithTag("panel2");
        panel3 = GameObject.FindGameObjectWithTag("panel3");
        panel1 .SetActive(false);
        panel2 .SetActive(false);
        panel3 .SetActive(false);
        infoPanel = GameObject.FindGameObjectWithTag("infoPanel");
        infoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
    
    public void showTab1(){
         if(panel1.activeSelf){
            panel1.SetActive(false);
        }else{
            panel1.SetActive(true);
            panel2.SetActive(false);
            panel3.SetActive(false);
        }
    }    
    public void showTab2(){
        if(panel2.activeSelf){
            panel2.SetActive(false);
        }else{
            panel2.SetActive(true);
            panel1.SetActive(false);
            panel3.SetActive(false);
        }
    }
    public void showTab3(){
        if(panel3.activeSelf){
            panel3.SetActive(false);
        }else{
            panel3.SetActive(true);
            panel2.SetActive(false);
            panel1.SetActive(false);
        }

        
    }

    public void closeGame(){
        Application.Quit();
    }
    public void closeInfoTab(){
        infoPanel.SetActive(false);
        }
    public void showInfoTab(){
        infoPanel.SetActive(true);
        panel3.SetActive(false);
        }
}
