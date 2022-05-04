using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageBase : MonoBehaviour
{
    public float HidePos = -2060;
    public float AnimTime = 0.5f;
    public iTween.EaseType CurveType = iTween.EaseType.easeOutQuart;
    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup)
        {
            canvasGroup.alpha = 0;
        }
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, HidePos);
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void Init()
    {

    }

    virtual public void Show()
    {
        gameObject.SetActive(true);
        iTween.Stop(this.gameObject);
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 0,
            "to", 1,
            "time", AnimTime,
            "onupdatetarget", this.gameObject,
            "onupdate", "UpdateAlpha",
            "oncompletetarget", this.gameObject,
            "oncomplete", "ShowAnimStoped",
            "easetype", CurveType));
    }

    void ShowAnimStoped()
    {
        
    }

    virtual public void Hide()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 1,
            "to", 0,
            "time", AnimTime,
            "onupdatetarget", this.gameObject,
            "onupdate", "UpdateAlpha",
            "oncompletetarget", this.gameObject,
            "oncomplete", "HideAnimStoped",
            "easetype", CurveType));
    }

    void HideAnimStoped()
    {
        gameObject.SetActive(false);
    }

    void UpdateAlpha(float val)
    {
        if (canvasGroup)
            canvasGroup.alpha = val;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Mathf.Lerp(HidePos, 0, val));
    }
}
