using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyemonster : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject eye;
    private int i = 0;
    private bool flg = false;

    int cnt = 0;

    void Start()
    {
        eye= GameObject.Find("pTorus36");
    }

    void Update()
    {
        GuruGuru();
    }

    void GuruGuru()
    {
        if (!flg)
        {
            var targetPos = player.transform.position;
            var targetRot = Quaternion.LookRotation(targetPos - eye.transform.position);
            eye.transform.rotation = Quaternion.RotateTowards(eye.transform.rotation, targetRot, Time.deltaTime * 150);
            RandumNum();
        }
        else
        {
            var targetPos = player.transform.position+new Vector3(Ranyeah(), Ranyeah(), Ranyeah());
            var targetRot = Quaternion.LookRotation(targetPos - eye.transform.position);
            eye.transform.rotation = Quaternion.RotateTowards(eye.transform.rotation, targetRot, Time.deltaTime * 360);

            cnt++;
            if (cnt>60)
            {
                cnt = 0;
                flg = false;
            }
        }
    }

    void RandumNum()
    {
        i = Random.Range(1, 10);
        if (i == 1)
        {
            flg = true;
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
