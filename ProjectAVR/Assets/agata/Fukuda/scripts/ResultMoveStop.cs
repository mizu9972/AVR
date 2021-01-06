using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ResultMoveStop : MonoBehaviour
{
    private SteamVR_Action_Boolean actionToHaptic = SteamVR_Actions._default.Teleport;
    private SteamVR_Action_Boolean grab = SteamVR_Actions._default.Grab;

    [SerializeField] private string SceneNameNow = "hora";
    [SerializeField] private string SceneName = "hora";
    [SerializeField] private GameObject startbutton;
    [SerializeField] private GameObject exitbutton;
    [SerializeField] private GameObject titlelogo;

    [SerializeField] private GameObject Player;

    private float chikachikatime = 1.0f;

    // public Button button;

    //[SerializeField]
    private bool pushflg = false;



    //　自身のボタンやトグル
    [SerializeField]
    private Selectable mySelectable;
    [SerializeField]
    private Selectable mySelectable2;

    private bool monflg = false;
    void Start()
    {
        //flg = false;
        //button.Select();
        //mySelectable = GetComponent<Selectable>();
        Player.GetComponent<trackpad>().enabled = false;
        SceneNameNow = SceneName;
    }

    private void Update()
    {


        if (grab.GetStateDown(SteamVR_Input_Sources.RightHand))
        //if(Input.anyKey) //testよう
        {
            pushflg = true;
        }

        SetSelectable();

        if (pushflg)
        {
            StartGame();

        }


    }

    public void SetSelectable()
    {
        //zatu.SetActive(false);
        
        if (actionToHaptic.GetStateDown(SteamVR_Input_Sources.RightHand))
        {


            if (SceneNameNow == SceneName)
            {
                SceneNameNow = "Exit";
                EventSystem.current.SetSelectedGameObject(mySelectable.navigation.selectOnRight.gameObject);
                startbutton.transform.GetChild(0).gameObject.SetActive(false);
                startbutton.transform.GetChild(1).gameObject.SetActive(false);
                exitbutton.transform.GetChild(0).gameObject.SetActive(true);
                exitbutton.transform.GetChild(1).gameObject.SetActive(true);


            }
            else if (SceneNameNow == "Exit")
            {
                SceneNameNow = SceneName;
                EventSystem.current.SetSelectedGameObject(mySelectable2.navigation.selectOnRight.gameObject);
                startbutton.transform.GetChild(0).gameObject.SetActive(true);
                startbutton.transform.GetChild(1).gameObject.SetActive(true);
                exitbutton.transform.GetChild(0).gameObject.SetActive(false);
                exitbutton.transform.GetChild(1).gameObject.SetActive(false);
            }

        }
    }



    public void OnClick()
    {
        if (SceneNameNow == "Exit")
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        if (SceneNameNow == "Exit")
        {
            FlagManager.Instance.ResetFlags();
            EndGame();
        }
        //titlelogo.SetActive(false);
        //Destroy(startbutton);
        //Destroy(exitbutton);
        //chika = true;
        //zatu.SetActive(true);
        FlagManager.Instance.ResetFlags();
        SceneManager.LoadScene(SceneNameNow);

    }
    public void EndGame()
    {
        SceneManager.LoadScene("Title");
    }
    private void LetsGo()
    {
        SceneManager.LoadScene(SceneNameNow);
    }


   
}
