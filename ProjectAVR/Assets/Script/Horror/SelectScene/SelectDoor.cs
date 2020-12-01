using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDoor : MonoBehaviour
{
    // animetion再生するよう
    Animator animator;

    // ステージenum
    public enum Door : short {
        Stage1,
        Stage2,
        Stage3,
        Max,
    }

    // このドアはどこに繋がっているか
    [SerializeField]
    private Door door;
    
    // ステージの文字列でロードする
    // そのために事前にリスト化
    readonly string[] doorName = new string[(int)Door.Max] {
        "Stage1",
        "Stage2",
        "Stage3"
    };

    // start-up
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // update
    private void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        // todo:　個々の部分本舘にパスしてロードを見直す
        //if (/*手が触れていてトリガーが引かれていたら*/)
        //{
        //    // animator.SetTrigger("opne");
        //    SceneManager.LoadScene(doorName[(int)door]);  
        //}
    }

}
