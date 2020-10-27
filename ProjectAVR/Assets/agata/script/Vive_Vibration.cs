using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Vive_Vibration : MonoBehaviour
{
    [SerializeField, Header("振動回数(Hz)")]
    private int PulseHertz = 100;
    [SerializeField, Header("振動の強さ"),Range(0.0f,1.0f)]
    private float PulseImpact = 1.0f;

    [SerializeField]
    SteamVR_Input_Sources[] hand = new SteamVR_Input_Sources[2] {
        SteamVR_Input_Sources.LeftHand,
        SteamVR_Input_Sources.RightHand
    };

    [SerializeField]
    SteamVR_Action_Boolean action;
    [SerializeField]
    SteamVR_Action_Vibration vibration;


    private bool m_VibrationActive = false;//バイブレーション有効化判定フラグ
    public bool VibrationActive//アクセサ
    {
        set
        {
            m_VibrationActive = value;
        }

        get
        {
            return m_VibrationActive;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //振動させる
        if (m_VibrationActive)
        {
            vibration.Execute(0, 0.16f, PulseHertz, PulseImpact, hand[0]);
            vibration.Execute(0, 0.16f, PulseHertz, PulseImpact, hand[1]);
        }
    }

    [ContextMenu("振動有効化")]
    public void StartVibration()
    {
        m_VibrationActive = true;
    }

    [ContextMenu("振動無効化")]
    public void StopVibration()
    {
        m_VibrationActive = false;
    }
}
