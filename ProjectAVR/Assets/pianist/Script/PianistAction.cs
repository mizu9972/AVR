using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianistAction : MonoBehaviour
{
    [SerializeField, Header("ピアニスト(人)オブジェクト")]
    private GameObject Pianist_Man = null;
    [SerializeField, Header("視界に収めていると判断するレンダラー")]
    private Renderer PianistRenderer = null;
    [SerializeField, Header("ピアニストのアニメーションスクリプト")]
    private PianistAnimation PianistAnim = null;

    [SerializeField, Header("プレイヤーオブジェクト")]
    private Transform PlayerTrans = null;

    [SerializeField, Header("プレイヤーの元に移動する際にプレイヤーと開ける間隔")]
    private float MovePointRadius = 0.5f;

    private Vector3 PianistPos = Vector3.zero;

    private bool isAttackableMode = false;
    private bool AttackFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        PianistPos = Pianist_Man.transform.position;

        if(PlayerTrans != null)
        {
            PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //攻撃可能状態なら一度視界を外れた後もう一度視界に入れたタイミングで攻撃
        if (PianistRenderer.isVisible)
        {
            //視界に入っている
            if (AttackFlag == true)
            {
                //椅子で攻撃アニメ
                PianistAnim.AttackwithChair();

                AttackFlag = false;
            }
        }
        else
        {
            //視界に入っていない
            if(isAttackableMode == true)
            {
                MoveAroundPlayer();

                AttackFlag = true;
            }
        }
    }

    [ContextMenu("移動")]
    //プレイヤーのそばへ瞬間移動
    private void MoveAroundPlayer()
    {
        //座標計算
        Vector3 subPos = Vector3.zero;
        subPos.x = judgeSign(PlayerTrans.position.x - PianistPos.x);
        subPos.y = 0;
        subPos.z = judgeSign(PlayerTrans.position.z - PianistPos.z);

        //座標決定
        Vector3 movePos = new Vector3(PlayerTrans.position.x - subPos.x * MovePointRadius, PianistPos.y, PlayerTrans.position.z - subPos.z * MovePointRadius);

        //プレイヤーと重ならないようにする
        Pianist_Man.transform.position = movePos;
        
    }

    public void setAttackMode(bool set)
    {
        isAttackableMode = set;
    }

    private float judgeSign(float num)
    {
        float retNum = 0;
        if(num > 0)
        {
            retNum += 1;
        }
        if(num < 0)
        {
            retNum -= 1;
        }
        return retNum;
    }
}
