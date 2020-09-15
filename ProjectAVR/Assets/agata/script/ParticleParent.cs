using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleParent : MonoBehaviour
{
    [SerializeField, Header("パーティクルシステムオブジェクト")]
    GameObject ParticleSystem = null;

   // ParticleSystem m_BulletParticle;
    // Start is called before the first frame update
    void Start()
    {
        //m_BulletParticle = ParticleSystem.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Shot")]
    public void Shot()
    {
        if (ParticleSystem != null)
        {
            Instantiate(ParticleSystem, transform.position, transform.rotation);
        }
    }
}
