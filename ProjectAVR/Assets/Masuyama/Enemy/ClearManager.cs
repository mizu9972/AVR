using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private static ClearManager instance = null;
    public static ClearManager Instance { get { return instance; } }

    public  void Clear()
    {

    }

    public void Over()
    {

    }
}
