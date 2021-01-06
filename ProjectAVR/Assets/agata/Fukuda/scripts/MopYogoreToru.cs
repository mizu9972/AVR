using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopYogoreToru : MonoBehaviour
{

    [SerializeField] private float alpha=0.3f;
    private Color col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "yogore")
        {
            col = other.GetComponent<Renderer>().material.color;

            col.a -= 0.3f;
            if(col.a < 0.0f)
            {
                col.a = 0.0f;
            }
            other.GetComponent<Renderer>().material.color = col;
    
        }


        Debug.Log("hit");
    }
}
