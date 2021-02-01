using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endscript : MonoBehaviour
{
    public GameObject canvas;
    public int flagNo = 127;
    public GameObject camera;
    private move_Player move;
    public Vector3 endpo;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        move = camera.GetComponent<move_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[flagNo])
        {
            canvas.SetActive(true);
            endpo.x = 6.52f;
            endpo.y = -1.819f;
            endpo.z = -6.12f;
            move.enabled = true;
        }
        else
        {
            canvas.SetActive(false);
        }
        move.endPosition = endpo;
    }
}
