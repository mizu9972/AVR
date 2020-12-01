using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ゲームのメイン部分のマネージャ
public class GameMainManager : MonoBehaviour
{
    // Mono側で継承とかやると面倒くさいので
    // 実データなどはGameSystemを継承させたやつらが行う

    GameSystem gameSystem = null;

    private void Start()
    {
        var nowStage = StageManager.Instance.Door;

        switch (nowStage)
        {
            case SelectDoor.Door.Stage1:
                // Stage1格納
                gameSystem = new Stage.Stage1();
                break;

            case SelectDoor.Door.Stage2:
                // Stage2格納
                gameSystem = new Stage.Stage2();
                break;

            case SelectDoor.Door.Stage3:
                // Stage3格納
                gameSystem = new Stage.Stage3();
                break;

            default:
                // Error
                Debug.Assert(false, "ステージに入っているのにステージ番号が設定されていません");
                break;
        }

        // エラーチェックはC#側が勝手にやってくれるはずなのでしましぇん

        // 生成したステージのStartを呼び出す
        gameSystem.Start();
    }

    private void Update()
    {
        // 現在のStageのUpdate呼び出し
        gameSystem.Update();
    }

}
