using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINav : MonoBehaviour
{
    
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    void Start()
    {
        panel1 = GameObject.FindGameObjectWithTag("panel1");
        panel2 = GameObject.FindGameObjectWithTag("panel2");
        panel3 = GameObject.FindGameObjectWithTag("panel3");
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
    
    public void showTab1(){
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }    
    public void showTab2(){
        panel1.SetActive(false);
        panel2.SetActive(true);
        panel3.SetActive(false);
    }
    public void showTab3(){
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(true);
    }


}
