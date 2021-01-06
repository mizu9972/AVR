using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
public class PianistAction : MonoBehaviour
{
    [SerializeField, Header("ピアニスト(人)オブジェクト")]
    private GameObject Pianist_Man = null;
    //[SerializeField, Header("視界に収めていると判断するレンダラー")]
    //private Renderer PianistRenderer = null;
    [SerializeField, Header("ピアニストのアニメーションスクリプト")]
    private PianistAnimation PianistAnim = null;

    [SerializeField, Header("プレイヤーオブジェクト")]
    private Transform PlayerTrans = null;

    [SerializeField, Header("プレイヤーの元に移動する際にプレイヤーと開ける間隔")]
    private float MovePointRadius = 0.5f;

    [SerializeField, Header("描画されているか判定スクリプト")]
    private judgeView Viewer = null;

    private Vector3 PianistPos = Vector3.zero;

    private bool isAttackableMode = false;
    private bool AttackFlag = false;
    private bool isInsideCamera = false;

    private bool isChairSwing = false;

    public bool IsChairSwing { get { return isChairSwing; } }

    // Start is called before the first frame update
    void Start()
    {
        PianistPos = Pianist_Man.transform.position;

        if(PlayerTrans != null)
        {
            PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        }

        //攻撃可能状態にする
        //開始直後は攻撃させない場合はfalse

        //３秒後にtrue
        Observable.Timer(System.TimeSpan.FromSeconds(3))
            .Subscribe(_ =>
        isAttackableMode = true);

    }

    // Update is called once per frame
    void Update()
    {
        //攻撃可能状態なら一度視界を外れた後もう一度視界に入れたタイミングで攻撃
        if (Viewer.isInsideCamera)
        {
            //視界に入っている
            if (AttackFlag == true)
            {
                //椅子で攻撃アニメ
                PianistAnim.AttackwithChair();

                Observable.Timer(System.TimeSpan.FromSeconds(1))
                    .Subscribe(_ =>
                isChairSwing = true);

                AttackFlag = false;
            }
        }
        else
        {
            //視界に入っていない
            if(isAttackableMode == true)
            {
                //プレイヤーのそばに移動
                MoveAroundPlayer();

                AttackFlag = true;
            }
        }
    }

    [ContextMenu("移動")]
    //プレイヤーのそばへ瞬間移動
    private void MoveAroundPlayer()
    {
        //座標差計算
        Vector3 subPos = Vector3.zero;
        subPos.x = PlayerTrans.position.x - PianistPos.x;
        subPos.y = 0;
        subPos.z = PlayerTrans.position.z - PianistPos.z;

        //符号判定
        Vector3 signPos;
        signPos.x = judgeSign(subPos.x);
        signPos.y = 0;
        signPos.z = judgeSign(subPos.z);

        //座標決定
        Vector3 movePos = new Vector3(PlayerTrans.position.x - signPos.x * MovePointRadius, PianistPos.y, PlayerTrans.position.z - signPos.z * MovePointRadius);

        //プレイヤーの方向を向く
        Quaternion LookRotation = Quaternion.LookRotation(subPos, Vector3.up);

        //反映する
        Pianist_Man.transform.position = movePos;
        Pianist_Man.transform.rotation = LookRotation;

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



    ///デバッグ用
    [ContextMenu("攻撃")]
    private void Debug_Attack()
    {
        MoveAroundPlayer();
        PianistAnim.AttackwithChair();
    }
}
