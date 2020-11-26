using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologcamera : MonoBehaviour
{
    Camera targetCamera;

    [SerializeField]
    Transform targetObj;
    GameObject houki;

    Rect rect = new Rect(0.3f, 0.3f, 0.7f, 0.7f);


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
