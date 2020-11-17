using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dast : MonoBehaviour
{
    private int gomikesi = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gomi")
        {
            Debug.Log("ダストシュート");
            other.gameObject.GetComponent<gomi>().gomimax = gomikesi;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
