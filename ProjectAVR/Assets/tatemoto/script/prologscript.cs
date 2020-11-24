using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologscript : MonoBehaviour
{
    public GameObject cap;
    // Start is called before the first frame update
    void Start()
    {
        Meshrender meshrender = cap.GetComponent<MeshRenderer>();
        meshrender.material.color = new Color(0, 0, 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cap.transform.rotation = Quaternion.Euler(45, 0, 0);
            meshrender.material.color = new Color(0, 0, 0, 0.0f);
        }
    }
}
