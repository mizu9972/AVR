using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyemonster : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject eye;
    private int i = 0;
    private bool flg = false;
    public GameObject SeSoundBox;
    private int tu = 6000;
    private int pe = 12000;

    private int nowPeTu = 0;

    int cnt = 0;

    void Start()
    {
        eye= GameObject.Find("pTorus36");
        nowPeTu = tu;
    }

    void Update()
    {
        GuruGuru();
    }

    void GuruGuru()
    {
        // flg = false;
        if (!flg)
        {
            var targetPos = player.transform.position;
            var targetRot = Quaternion.LookRotation(targetPos - eye.transform.position);
            eye.transform.rotation = Quaternion.RotateTowards(eye.transform.rotation, targetRot, Time.deltaTime * 150);
            nowPeTu = tu;
        }
        else
        {
            var targetPos = player.transform.position+new Vector3(Ranyeah(), Ranyeah(), Ranyeah());
            var targetRot = Quaternion.LookRotation(targetPos - eye.transform.position);
            eye.transform.rotation = Quaternion.RotateTowards(eye.transform.rotation, targetRot, Time.deltaTime * 360);
            nowPeTu = pe;
        }


        cnt++;
        if (cnt > nowPeTu)
        {
            RandumNum();
            cnt = 0;
            // flg = false;
        }
    }

    void RandumNum()
    {
        i = Random.Range(1, 5);
        flg = i == 1;
        if(flg)
        {
            SeSoundBox.GetComponent<PlaySe>().PlaySound(1);
        }
        else
        {
            SeSoundBox.GetComponent<PlaySe>().PlaySound(0);
        }
    }

    int Ranyeah()
    {
        int j = Random.Range(-5, 6);
        if (j <= 0)
        {
            j = -5;
        }
        else
        {
            j = 6;
        }
        return j;
    }
}
