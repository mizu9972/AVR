using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houkisc : MonoBehaviour
{
    private int gomi = 0;
    Rigidbody rb;
    public float velocity = 30.0f;
    private float scalel = 0.01f;
    private float scalex = 1.0f;
    private float scaley= 1.0f;
    private float scalez = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody>();
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "yogore")
        {
            rb = this.transform.GetComponent<Rigidbody>();
            Debug.Log(rb.velocity.magnitude);
            if (rb.velocity.magnitude < velocity)
            {
                Debug.Log("押す");
                if (scalex >= 0.0f)
                {
                    scalex = scalex - scalel;
                    scaley = scaley - scalel;
                    scalez = scalez - scalel;
                }
                int gomipara = other.gameObject.GetComponent<gomi>().gomimax;
                gomi = -1;
                other.gameObject.GetComponent<gomi>().gomimax = gomipara + gomi;
                other.gameObject.transform.localScale = new Vector3(scalex, scaley, scalez);
            }
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
