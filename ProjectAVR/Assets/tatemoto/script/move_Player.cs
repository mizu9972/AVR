using UnityEngine;
using System.Collections;

public class move_Player : MonoBehaviour
{

    [SerializeField, Range(0, 10)]
    float time = 1;

    [SerializeField]
    public Vector3 endPosition;
    public int selectNo;
    public bool endflag = false;

    //[SerializeField]
    //AnimationCurve curve;

    private float startTime;
    private Vector3 startPosition;

    void OnEnable()
    {
        if (time <= 0)
        {
            transform.position = endPosition;
            enabled = false;
            return;
            //endflag = false;
        }
        startTime = Time.timeSinceLevelLoad;
        startPosition = transform.position;
    }

    void Update()
    {
        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > time)
        {
            transform.position = endPosition;
            enabled = false;
            endflag= true;
            if (FlagManager.Instance.flags[4])
            {
                FlagManager.Instance.flags[5] = true;
            }
        }

        var rate = diff / time;
        //var pos = curve.Evaluate(rate);

        transform.position = Vector3.Lerp(startPosition, endPosition, rate);
        //transform.position = Vector3.Lerp (startPosition, endPosition, pos);
    }

    void OnDrawGizmosSelected()
    {
#if UNITY_EDITOR

		if( !UnityEditor.EditorApplication.isPlaying || enabled == false ){
			startPosition = transform.position;
		}

		UnityEditor.Handles.Label(endPosition, endPosition.ToString());
		UnityEditor.Handles.Label(startPosition, startPosition.ToString());
#endif
        Gizmos.DrawSphere(endPosition, 0.1f);
        Gizmos.DrawSphere(startPosition, 0.1f);

        Gizmos.DrawLine(startPosition, endPosition);
    }
}
