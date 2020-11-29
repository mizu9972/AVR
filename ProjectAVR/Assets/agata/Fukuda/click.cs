using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Awake()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
  
    }


    
    private void OnTriggerStay(Collider collision)
    {

        GetComponent<Renderer>().material.color = Color.green;
        if (collision.gameObject.name == "Button")
        {
               
            Debug.Log("接触中");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("接触中");
    }
}
