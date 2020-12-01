using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem
{
    // ゴミをすべて処理したフラグ
    protected bool allCleanFlag = false;

    // ゲームオーバーフラグ
    protected bool gameOverFlag = false;

    // Start is called before the first frame update
    public void Start()
    {
        Debug.LogWarning("基底のStart()が呼ばれています");
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.LogWarning("基底のUpdate()が呼ばれています");
    }


}
