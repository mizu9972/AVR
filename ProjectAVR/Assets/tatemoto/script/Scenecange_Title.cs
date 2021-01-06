using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenecange_Title : MonoBehaviour
{
    public int scenecangeflag;
    public string scenename;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[scenecangeflag])
        {
            FlagManager.Instance.ResetFlags();
            SceneManager.LoadScene(scenename);
        }
    }
}
