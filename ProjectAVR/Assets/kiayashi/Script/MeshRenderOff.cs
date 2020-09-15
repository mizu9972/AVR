using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRenderOff : MonoBehaviour
{
    MeshRenderer MyRenderer;
    // Start is called before the first frame update
    void Start()
    {
        MyRenderer = this.GetComponent<MeshRenderer>();
        MyRenderer.enabled = false;
    }
}
