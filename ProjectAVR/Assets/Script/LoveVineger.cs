using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveVineger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] loveVineger;

    [SerializeField]
    private GameObject vineger;

    private bool flg = false;

    private int num = 0;

    void Start()
    {
        loveVineger = GetComponentsInChildren<GameObject>();
    }

    void Update()
    {
        for (int i = 0; i < loveVineger.Length; i++)
        {
            if (loveVineger[i] == null)
            {
                num++;
            }
        }

        if (num >= loveVineger.Length)
        {
            flg = true;
        }
        else
        {
            num = 0;
        }

        if (flg)
        {
            Debug.Log("yeahhhhhhhh");
        }
    }
}
