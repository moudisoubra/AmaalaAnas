using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmallTitleAnim : MonoBehaviour
{
    public float AnimTime = 0.5f;
    public iTween.EaseType CurveType = iTween.EaseType.easeOutQuart;
    public bool StartOnEnable = false;

    TMP_Text Text;
    BrunoMikoski.TextJuicer.TMP_TextJuicer TitleTextJuicer;
    Image Line;

    private void Awake()
    {
        Text = GetComponent<TMP_Text>();
        TitleTextJuicer = GetComponent<BrunoMikoski.TextJuicer.TMP_TextJuicer>();
        Line = GetComponentInChildren<Image>();
        ResetTextPro();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        UpdateLineScale(0);
        ResetTextPro();
        Loom.QueueOnMainThread(() => { if (StartOnEnable) { StartAnim(0); } }, 0.5f);
    }

    public void StartAnim(float delay)
    {
        iTween.Stop(this.gameObject);
        iTween.ValueTo(gameObject, iTween.Hash(
                "from", 0f,
                "to", 1f,
                "time", AnimTime,
                "delay", delay,
                "onupdatetarget", this.gameObject,
                "onupdate", "UpdateLineScale",
                "oncompletetarget", this.gameObject,
                "oncomplete", "LineAnimationStoped",
                "easetype", CurveType));
        TitleTextJuicer.Play();
    }

    void UpdateLineScale(float val)
    {
        if(Line)
            Line.transform.localScale = new Vector3(val, 1, 1);
    }

    void LineAnimationStoped()
    {
        /*if (Text)
            ResetTextPro();
        TitleTextJuicer.Play();*/
        
    }

    public void Hide()
    {
        if(Text)
            ResetTextPro();
        UpdateLineScale(0);
    }

    void ResetTextPro()
    {
        TitleTextJuicer.SetProgress(0);
        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 0);
        //TitleTextJuicer.Stop();
    }
}
