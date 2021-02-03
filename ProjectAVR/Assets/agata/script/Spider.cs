using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class Spider : MonoBehaviour
{
    private Vector3 centerPos;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject kumo;
    [SerializeField] private float hankei;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float moveTime;
    [SerializeField] private float stopTime;

    [SerializeField] private int killFlagNumber;

    [SerializeField, Header("頭上に来たと判定する距離")]
    private float HeadDistance = 0.5f;
    [SerializeField, Header("攻撃アニメーションに移る時間")]
    private float KillTimer = 1.0f;

    private bool flg = true;
    private bool killflg = false;
    public bool Flg { get { return flg; } }
    public bool KillFlg { get { return killflg; } }

    private Animator animator;
    private Rigidbody myRigid = null;
    private Vector3 defaultPose;

    private void Start()
    {

        //targetPosition = GetRandomPosition();
        //targetPosition.position = this.transform.position;

        defaultPose = kumo.transform.localRotation.eulerAngles;
        centerPos = this.transform.position;
        this.transform.position = this.transform.position + new Vector3(hankei, 0, 0);
        moveTime = MoveTime();
        stopTime = StopTime();

        animator = GetComponentInChildren<Animator>();
        myRigid = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        moveTime -= Time.deltaTime;

        //NormalMove();

        //if (FlagManager.Instance.flags[killFlagNumber])
        if (flg)
        {
            GoToDIE();
        }
        if (killflg)
        {
            FallOut();
        }
    }

    //降りてくる
    private void FallOut()
    {

        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), 1f * Time.deltaTime);

        //指定時間後にKillAniを呼ぶ
        Observable.Timer(System.TimeSpan.FromSeconds(KillTimer)).Subscribe(_ =>
        {
            KillAni();
        });
    }

    // もぐもぐ
    private void KillAni()
    {
        animator.SetTrigger("Walk");

        //var aim = player.transform.position - kumo.transform.position;
        //var look = Quaternion.LookRotation(new Vector3(aim.x * -1, aim.y, aim.z));
        //kumo.transform.localRotation = look;

        //this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z), 1f * Time.deltaTime);
    }

    // プレイヤーの真上まで行く
    private void GoToDIE()
    {
        animator.SetTrigger("Walk");
        
        var aim = player.transform.position - kumo.transform.position;
        var look = Quaternion.LookRotation(new Vector3(aim.x*-1, 0, aim.z));
        kumo.transform.localRotation = look;

        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z), 1f * Time.deltaTime);

        //頭上に到達
        if (aim.x <= HeadDistance && aim.z <= HeadDistance)
        {
            aim = player.transform.position - kumo.transform.position;
            look = Quaternion.LookRotation(new Vector3(aim.x, -1 * aim.y,aim.z));
            kumo.transform.localRotation = look;
            animator.SetTrigger("Stop");
            killflg = true;
            flg = false;
        }
    }

    private void NormalMove()
    {


        //moveTimeが0以上なら行動する
        if (moveTime > 0)
        {

            //正面に進む
            //this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //Quaternion targetRotation = Quaternion.LookRotation(initPos - this.transform.position);
            //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime );
            animator.SetTrigger("Walk");
            transform.RotateAround(centerPos, new Vector3(0, -1.0f, .0f), speed * Time.deltaTime);
        }
        else
        {
            animator.SetTrigger("Stop");
        }
        //moveTimeが0以下なら次のポイントを設定する
        if (moveTime < 0)
        {
            stopTime -= Time.deltaTime;
            if (stopTime < 0)
            {
                moveTime = MoveTime();
                stopTime = StopTime();
            }


            //targetPosition = GetRandomPosition();
            //Debug.Log(targetPosition);
        }
    }

    public float MoveTime()
    {
        return Random.Range(1f, 3f);
    }
    public float StopTime()
    {
        return Random.Range(0.5f, 1f);
    }
}
