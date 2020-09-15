using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private static GameManager instance = null;
    public static GameManager Instance { get {  return instance; } }
    
    public void GameEnd(bool _clear)
    {
        if (_clear) ClearManager.Instance.Clear();
        else ClearManager.Instance.Over();
    }
}
