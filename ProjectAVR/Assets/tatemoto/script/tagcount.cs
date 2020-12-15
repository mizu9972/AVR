using UnityEngine;
using System.Collections;

public class tagcount : MonoBehaviour
{
    public string tag;
    public int flagNo = 0;
    public int count = 0;
    GameObject[] tagObjects;

    float timer = 0.0f;
    float interval = 2.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Check(tag);
            timer = 0;
        }
    }

    void Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数
        if (tagObjects.Length == 0)
        {
            Debug.Log(tagname + "タグがついたオブジェクトはありません");
            FlagManager.Instance.flags[flagNo] = true;
        }
    }
}
