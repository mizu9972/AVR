using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletpara : MonoBehaviour
{
    public float bullet_life;
    public float bullet_speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,bullet_life);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward * bullet_speed);
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Enemy")
        {
            //Destroy(this.gameObject);
        }
    }
}
