using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mopsound : MonoBehaviour
{
    public AudioClip audioClip1;
    private AudioSource audioSource;
    public float volume;
    public float max=1.0f;
    public float mini=0.0f;
    private float n = 1;
    Rigidbody rb;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        //audioSource.volume = volume;
        rb = this.transform.GetComponent<Rigidbody>();
    }
    public void OnCollisionEntery(Collider other)
    {
        audioSource.volume = volume;
        audioSource.Play();
        
    }
    void Update()
    {
        n = max - mini;
        if(mini>=rb.velocity.magnitude)
        {
            volume = 0.1f;
        }
        else
        {
            if (n + mini >= rb.velocity.magnitude)
            {
                volume = 0.2f;
            }
            else
            {
                if ( n*2.0+mini >= rb.velocity.magnitude)
                {
                    volume = 0.3f;
                }
                else
                {
                    if (n*3.0+mini >= rb.velocity.magnitude)
                    {
                        volume = 0.4f;
                    }
                    else
                    {
                        if (n*4.0+mini >= rb.velocity.magnitude)
                        {
                            volume = 0.5f;
                        }
                        else
                        {
                            if (n*5.0+mini >= rb.velocity.magnitude)
                            {
                                volume = 0.6f;
                            }
                            else
                            {
                                if (n*6.0+mini >= rb.velocity.magnitude)
                                {
                                    volume = 0.7f;
                                }
                                else
                                {
                                    if (n*7.0+mini >= rb.velocity.magnitude)
                                    {
                                        volume = 0.8f;
                                    }
                                    else
                                    {
                                        if (n*9.0+mini >= rb.velocity.magnitude)
                                        {
                                            volume = 0.9f;
                                        }
                                        else
                                        {
                                            volume = 1.0f;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
       
    }
}
