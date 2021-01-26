using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Buttonsan : MonoBehaviour
{
    private SteamVR_Action_Boolean actionToHaptic = SteamVR_Actions._default.Teleport;
    private SteamVR_Action_Boolean grab = SteamVR_Actions._default.Grab;

    [SerializeField] private string SceneNameNow = "hora";
    [SerializeField]private string SceneName = "hora";

    [SerializeField] private GameObject pushimage;
    [SerializeField] private GameObject startbutton;
    [SerializeField] private GameObject exitbutton;
    [SerializeField] private GameObject titlelogo;
    [SerializeField] private GameObject lightdi;


    private float chikachikatime = 1.0f;

    // public Button button;

    //[SerializeField]
    private bool pushflg = false;

    

    //　自身のボタンやトグル
    [SerializeField]
    private Selectable mySelectable;
    [SerializeField]
    private Selectable mySelectable2;

    [SerializeField] private bool chika = false;

    [SerializeField] private float timel = 0.0f;

    private bool flg = true;
    private bool lightflg = false;
    private float timekun=0.0f;

    private bool starttutorial = false;

    [SerializeField] private GameObject eye;
    [SerializeField] private GameObject kumo;
    [SerializeField] private GameObject pianist;
    [SerializeField] private int jk=0;
    [SerializeField] private float timef = 0.0f;

    [SerializeField] private GameObject zatu;
    private bool monflg = false;
    void Start()
    {
        //flg = false;
        //button.Select();
        //mySelectable = GetComponent<Selectable>();
        chikachikatime = 1.0f;
        SceneNameNow = SceneName;
        chika = false;
    }

    private void Update()
    {

        if (!chika)
        {
            if (grab.GetStateDown(SteamVR_Input_Sources.RightHand))
            //if(Input.anyKey) //testよう
            {

                if (pushflg)
                {
                    StartGame();

                }
                pushflg = true;

            }
            if (pushflg)
            {
                SetSelectable();
                pushimage.SetActive(false);
                startbutton.SetActive(true);
                exitbutton.SetActive(true);
                zatu.SetActive(true);

            }
            monsutaderu();
        }
        else
        {
            Kieru();
        }
    }

    public void SetSelectable()
    {
        zatu.SetActive(false);
        //　タブキーを押されたらSelectOnRightに選択された物をフォーカスする
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




    public void nextbutton()
    {

    }
    public void OnClick()
    {
        if(SceneNameNow == "Exit")
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        if (SceneNameNow == "Exit")
        {
            EndGame();
        }
        titlelogo.SetActive(false);
        Destroy(startbutton);
        Destroy(exitbutton);
        chika = true;
        zatu.SetActive(true);
        //SceneManager.LoadScene(SceneNameNow);

    }
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
		Application.Quit();
#endif
    }
    private void LetsGo()
    {
        SceneManager.LoadScene(SceneNameNow);
    }

 
    private void Kieru()
    {
     
        if (!lightflg)
        {
            timekun += Time.deltaTime;

            if (timekun >= chikachikatime)
            {

                if (flg)
                {
                    lightdi.SetActive(false);
                    flg = false;
                }
                else if (!flg)
                {
                    lightdi.SetActive(true);
                    flg = true;
                   
                }
                if (timel > 15.0f)
                {
                    lightflg = true;
                    timel = 0.0f;
                }
                timel += 1.0f;
                timekun = 0.0f;
                chikachikatime -= 0.2f;
                if(chikachikatime<0.1f)
                {
                    chikachikatime = 0.1f;
                }
            }
        }
        else if (lightflg)
        {
            
            timekun += Time.deltaTime;

            if (timekun >= 1.0f)
            {

                if(timel < 2.0f)
                {
                    lightdi.SetActive(false);
                }
                else
                {
                    //lightdi.SetActive(true);
                    //eye.SetActive(false);
                    //kumo.SetActive(true);
                }


                timel += 1.0f;

                timekun = 0.0f;

                

                if(timel>1.0f)
                {
                    SceneManager.LoadScene(SceneNameNow);
                }
            }
        }
    }


    private void monsutaderu()
    {
        

        timef+=Time.deltaTime;
        if(timef>=6)
        {
            lightdi.SetActive(true);
            timef = 0;
            monflg = false;
        }
        if (timef>=5.0f && monflg==false)
        {
            switch(jk)
            {
                case 0:
                    {
                        lightdi.SetActive(false);
                        eye.SetActive(true);
                        kumo.SetActive(false);
                        pianist.SetActive(false);
                        monflg = true;
                        jk = 1;
                      
                        break;
                    }
                case 1:
                    {
                        lightdi.SetActive(false);
                        eye.SetActive(false);
                        kumo.SetActive(true);
                        pianist.SetActive(false);
                        monflg = true;
                        jk = 2;
                      
                        break;
                    }
                case 2:
                    {
                        lightdi.SetActive(false);
                        eye.SetActive(false);
                        kumo.SetActive(false);
                        pianist.SetActive(true);
                        monflg = true;
                        jk = 0;
                    
                        break;
                    }

                  
            }
        }
    }
}
