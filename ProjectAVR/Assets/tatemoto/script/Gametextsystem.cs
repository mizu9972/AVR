using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gametextsystem : MonoBehaviour
{
    [SerializeField]
    eptext textController;
    public int flgno;

    bool IsTextPush = false;
    void Update()
    {
        textController.TextUpdate(IsTextPush);
        IsTextPush = false;
        if (FlagManager.Instance.flags[flgno])
        {
            PushText();
            FlagManager.Instance.flags[flgno] = false;
        }
    }
    public void PushText()
    {
        this.IsTextPush = true;
    }
}
