using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Switch : MonoBehaviour
{
    [Header("置換する配列の番号")]
    public int ArrayNum;

    [Header("切り替えするオブジェクト")]
    public Transform[] SwithObj = new Transform[2];

    [SerializeField, Header("スイッチの状態")]
    private bool isSwtOn = false;

    [Header("コースタースクリプトの本体")]
    public Coaster coaster;

    [Header("ActionsTestスクリプト")]
    public ActionsTest actionsTest;

    private Transform NowObj;//現在有効化されているオブジェクト
    private int NowCount;

    // Start is called before the first frame update
    void Start()
    {
        //スイッチの変数が変更される度に
        //Coasterのターゲットを変更するストリームを登録
        this.ObserveEveryValueChanged(x => NowObj)
            .Where(x => x)
            .Subscribe(_ => coaster.SetTargetObj(ArrayNum, NowObj));
    }

    // Update is called once per frame
    void Update()
    {
        if(actionsTest.GetGrab()&&ArrayNum!=coaster.GetCount())
        {
            switch (isSwtOn)
            {
                case true:
                    SwitchOff();
                    break;
                case false:
                    SwitchOn();
                    break;
            }
        }
        //テスト
        if(Input.GetKeyDown(KeyCode.Return) && ArrayNum != coaster.GetCount())
        {
            switch(isSwtOn)
            {
                case true:
                    SwitchOff();
                    break;
                case false:
                    SwitchOn();
                    break;
            }
        }
    }

    public void SwitchOn()//スイッチオン
    {
        isSwtOn = true;
        NowObj = SwithObj[1];
    }

    public void SwitchOff()//スイッチオフ
    {
        isSwtOn = false;
        NowObj = SwithObj[0];
    }
}
