using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentItemAnim : MonoBehaviour
{
    public float AnimTime = 0.5f;
    public iTween.EaseType CurveType = iTween.EaseType.easeOutQuart;
    public BrunoMikoski.TextJuicer.TMP_TextJuicer TitleTextJuicer;
    public BrunoMikoski.TextJuicer.TMP_TextJuicer DescTextJuicer;
    public SmallTitleAnim SmallTitle;
    float StartPos = 0;
    float HidePos = 0;

    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartPos = GetComponent<RectTransform>().anchoredPosition.y;
        HidePos = StartPos - 400;
        HideContent();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowContent()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 0,
            "to", 1,
            "time", AnimTime,
            "onupdatetarget", this.gameObject,
            "onupdate", "UpdateValue",
            "oncompletetarget", this.gameObject,
            "oncomplete", "AnimComplete",
            "easetype", CurveType));
        if (TitleTextJuicer){ TitleTextJuicer.Play(); }
        if (DescTextJuicer) { DescTextJuicer.Play(); }
        if (SmallTitle) { SmallTitle.StartAnim(0); }
    }

    public void HideContent()
    {
        UpdateValue(0);
        if (SmallTitle) { SmallTitle.Hide(); }
    }

    void UpdateValue(float val)
    {
        Vector2 newPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, Mathf.Lerp(HidePos, StartPos, val));
        GetComponent<RectTransform>().anchoredPosition = newPosition;
        canvasGroup.alpha = val;
    }

    void AnimComplete()
    {

    }
}
