using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSelfDelete : MonoBehaviour
{
    ParticleSystem m_ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        m_ParticleSystem = this.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_ParticleSystem.isPlaying == false)
        {
            Destroy(this.gameObject);
        }
    }
}
