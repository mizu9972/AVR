using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorchange : MonoBehaviour
{
    public GameObject camera;
    public Color outlineColor;
    public int cnt = 60;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        outlineColor=camera.GetComponent<OutlinePostEffect>().outlineColor;
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        if(cnt/2==i)
        {
            FlagManager.Instance.flags[2] = true;
        }
        if(cnt==i)
        {
            FlagManager.Instance.flags[2] = false;
            i = 0;
        }
        if(FlagManager.Instance.flags[2]==true)
        {
            outlineColor.g = 1.0f;
        }
        if (FlagManager.Instance.flags[2] == false)
        {
            outlineColor.g = 0.5f;
        }

        camera.GetComponent<OutlinePostEffect>().outlineColor = outlineColor;
    }
}
