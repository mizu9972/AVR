using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たり判定処理
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hit");
    }
}
