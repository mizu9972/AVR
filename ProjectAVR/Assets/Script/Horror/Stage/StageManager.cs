using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 現在のステージナンバーを管理するクラス
// 今回は小規模開発なのでSingletonを使用

public class StageManager: System.Singleton<StageManager>
{
    // ステージ外ではMaxに
    private SelectDoor.Door nowDoor = SelectDoor.Door.Max;

    // ドアデータを設定
   public SelectDoor.Door Door { get{ return nowDoor; } set { nowDoor = value; } }
}
