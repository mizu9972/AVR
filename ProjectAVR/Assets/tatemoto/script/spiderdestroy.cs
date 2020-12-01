using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderdestroy : MonoBehaviour
{
    private int hp = 0;
    Rigidbody rb;
    public float velocity = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody>();
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "spider"|| other.gameObject.tag == "minispider")
        {
            rb = this.transform.GetComponent<Rigidbody>();
            Debug.Log(rb.velocity.magnitude);
            //if (rb.velocity.magnitude < velocity)
            //{
                Debug.Log("押す");
                int hppara = other.gameObject.GetComponent<spider>().hpmax;
                hp = -1;
                other.gameObject.GetComponent<spider>().hpmax = hppara + hp;
            //}
        }
    }
    // 1
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "spider" || other.gameObject.tag == "minispider")
        {
            Debug.Log("引く");
            hp = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
