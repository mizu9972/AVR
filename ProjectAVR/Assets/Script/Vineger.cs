using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vineger : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (this != null)
        {
            Destroy(this.gameObject);
        }
    }
}
