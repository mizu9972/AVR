using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraray : MonoBehaviour
{
    Camera targetCamera; 

    [SerializeField]
    Transform targetObj;

    Rect rect = new Rect(0.2f, 0.2f, 0.8f, 0.8f);


    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        var viewportPos = targetCamera.WorldToViewportPoint(targetObj.position);

        if (rect.Contains(viewportPos))
            ShowText("画面内にいるよ");
        else
        {
            ShowText("画面外だよ");
        }

    }

    // 以下はサンプルのUI表示用
    [SerializeField]
    Text uiText;
    void ShowText(string message)
    {
        uiText.text = message;
    }
}