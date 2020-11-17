using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologscript : MonoBehaviour
{
    public GameObject cap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cap.transform.rotation = Quaternion.Euler(45, 0, 0);
        }
    }
}
