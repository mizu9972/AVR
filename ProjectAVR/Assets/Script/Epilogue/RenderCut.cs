using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCut : MonoBehaviour
{
    public MeshRenderer MyRender = null;
    // Start is called before the first frame update
    void Awake()
    {
        MyRender.enabled = false;//非描画状態に切り替え
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
