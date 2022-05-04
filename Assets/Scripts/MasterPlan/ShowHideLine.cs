using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowHideLine : MonoBehaviour
{
    public GameObject LineObj;
    public float AnimTime = 0.5f;
    public iTween.EaseType CurveType = iTween.EaseType.easeOutQuart;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(float delay)
    {
        if (LineObj.transform.localScale != Vector3.one)
        {
            StartAnim(0, 1, delay);
        }
    }

    public void Hide(float delay)
    {
        if (LineObj.transform.localScale == Vector3.one)
        {
            StartAnim(1, 0, delay);
        }
    }

    void StartAnim(float a, float b, float delay)
    {
        iTween.Stop(this.gameObject);
        iTween.ValueTo(gameObject, iTween.Hash(
                "from", a,
                "to", b,
                "time", AnimTime,
                "delay", delay,
                "onupdatetarget", this.gameObject,
                "onupdate", "UpdateLineScale",
                "oncompletetarget", this.gameObject,
                "oncomplete", "AnimationStoped",
                "easetype", CurveType));
    }

    void UpdateLineScale(float val)
    {
        if (LineObj)
            LineObj.transform.localScale = new Vector3(val, 1, 1);
    }

    void AnimationStoped()
    {
        
    }
}
