using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    private Vector3 centerPos;

    [SerializeField] private float hankei;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float moveTime;
    [SerializeField] private float stopTime;

    private void Start()
    {

        //targetPosition = GetRandomPosition();
        //targetPosition.position = this.transform.position;

        centerPos = this.transform.position;
        this.transform.position = this.transform.position + new Vector3(hankei, 0, 0);
        moveTime = MoveTime();
        stopTime = StopTime();
    }
    // Update is called once per frame
    void Update()
    {
        moveTime -= Time.deltaTime;
        //moveTimeが0以上なら行動する
        if (moveTime > 0)
        {
            //正面に進む
            //this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //Quaternion targetRotation = Quaternion.LookRotation(initPos - this.transform.position);
            //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime );

            transform.RotateAround(centerPos, new Vector3(0, 1.0f, .0f), speed * Time.deltaTime);
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
