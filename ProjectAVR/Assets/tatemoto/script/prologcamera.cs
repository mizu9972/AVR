using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologcamera : MonoBehaviour
{
    Camera targetCamera;

    [SerializeField]
    Transform targetObj;
    GameObject houki;

    Rect rect = new Rect(0.4f, 0.4f, 0.6f, 0.6f);


    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        var viewportPos = targetCamera.WorldToViewportPoint(targetObj.position);

        if (rect.Contains(viewportPos))
        {
            FlagManager.Instance.flags[0] = true;
        }
        else
        {

        }

    }
}
