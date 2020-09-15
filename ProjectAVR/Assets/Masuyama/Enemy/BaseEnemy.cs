using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    enum Status
    {
        Live,
        End,
        Max,
    }

    [SerializeField] protected int hp;
    [SerializeField] protected int atk;

    private Status status;

    // Start is called before the first frame update
    void Start()
    {
        status = Status.Live;
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case Status.Live:
                LiveUpdate();
                break;
            case Status.End:
                EndUpdate();
                break;
        }   
    }

    void LiveUpdate()
    {

    }

    void EndUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // トロッコが当たったら
            var top = other.transform.root;

            // 死亡かダメージ処理を送る
            // var player=top.GetComponentInChildren<Player>();
        }
    }

    void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "Bullet")
        {
            // バレットが当たったら
            // 今回ダメージの概念がないのでhpを減らす
            hp--;

            // 死ぬ可能性は当たった時のみなのでここで条件分岐
            if (hp == 0)
            {
                status = Status.End;
            }
        }
    }
}
