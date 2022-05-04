using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeInOutAnim : MonoBehaviour
{
    public float AnimTime = 0.5f;
    public iTween.EaseType CurveType = iTween.EaseType.easeOutQuart;
    public UnityEvent FadeInEvent;
    public UnityEvent FadeOutEvent;

    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn(float delay)
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 0;
        StartAnim(0, 1, delay);
    }

    public void FadeOut(float delay)
    {
        StartAnim(1, 0, delay);
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
        if (canvasGroup)
            canvasGroup.alpha = val;
    }

    void AnimationStoped()
    {
        if(canvasGroup.alpha == 0)
        {
            gameObject.SetActive(false);
            FadeOutEvent.Invoke();
        }
        else
        {
            FadeInEvent.Invoke();
        }
    }
}
