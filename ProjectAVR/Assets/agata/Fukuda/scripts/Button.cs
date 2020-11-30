using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using UnityEngine.UI;
public class Button : MonoBehaviour
{
    private SteamVR_Action_Boolean actionToHaptic = SteamVR_Actions._default.TitleCheck;

    [SerializeField] private string SceneName = "Game";
         
    public void OnClick()
    {
        if(SceneName == "Exit")
        {
            EndGame();
        }
        else
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Laser")
        {
            this.gameObject.GetComponent<Image>().color = Color.red;

            if (actionToHaptic.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                OnClick();
            }
            
        }
        Debug.Log("clicked");
    }

    void OnTriggerExit(Collider collision)
    {
        this.gameObject.GetComponent<Image>().color = Color.white;
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
		Application.Quit();
#endif
    }
}
