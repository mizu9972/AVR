using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houkisc : MonoBehaviour
{
    private int gomi = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gomi")
        {
            Debug.Log("押す");
            int gomipara = other.gameObject.GetComponent<gomi>().gomimax;
            gomi = -1;
            other.gameObject.GetComponent<gomi>().gomimax = gomipara + gomi;
        }
    }
    // 1
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "gomi")
        {
            Debug.Log("引く");
            gomi = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
