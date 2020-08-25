using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private string GameSceneName;

    void Start()
    {
        
    }

    public void GoGameScene() {
        SceneManager.LoadScene(GameSceneName);
    }

    public void Exit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
