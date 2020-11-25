using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using UnityEngine.UI;
public class Button : MonoBehaviour
{
    private SteamVR_Action_Boolean actionToHaptic = SteamVR_Actions._default.TitleCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        SceneManager.LoadScene("HunikiDevelop");
       
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
}
