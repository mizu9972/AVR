using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootdele : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collision other)
    {
        if (other.gameObject.tag == "filerd")
        {
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
