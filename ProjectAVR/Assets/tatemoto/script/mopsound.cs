using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mopsound : MonoBehaviour
{
    public AudioClip audioClip1;
    private AudioSource audioSource;
    public float volume;
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
        audioSource.Play();
        rb = this.transform.GetComponent<Rigidbody>();
        volume = rb.velocity.magnitude;
    }
    void Update()
    {

    }
}
