using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraray1 : MonoBehaviour
{
    public GameObject camera;
    public GameObject hitobj;
    public float radius;
    public int itime;
    private int time;

    [SerializeField] private int flgno = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray=new Ray(camera.transform.position, camera.transform.forward);
        if(Physics.SphereCast(ray, radius, out hit))
        {
            if(hit.collider.gameObject==hitobj)
            {
                if(itime*30<=time)
                {
                    // Destroy(hitobj);
                    FlagManager.Instance.flags[flgno] = true;
                }
            }
            else
            {
                
            }
            time++;
        }
        else
        {
            time = 0;
        }
    }
}
