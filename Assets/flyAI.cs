using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyAI : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 position;
    private Vector2 target;
    private float speed = 2f;

    void Start()
    {
        target = new Vector2(10,-5);
        position = gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,target,step);
        

        if(Vector2.Distance(transform.position,target)<0.1f){
            Destroy(transform.root.gameObject);
            }        
        }

    void OnMouseDown(){
        print("got eem");
    }
}


