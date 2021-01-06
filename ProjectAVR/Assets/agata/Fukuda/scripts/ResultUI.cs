using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public GameObject canvas;
    public int flagNo;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[flagNo])
        {
            this.transform.position = new Vector3(1000, 1000, 1000);
            canvas.transform.position = new Vector3(1000, 1000, 1000);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }
}
