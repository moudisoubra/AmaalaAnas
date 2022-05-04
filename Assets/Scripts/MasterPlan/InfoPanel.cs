using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public float HidePannelPos = 1110;
    public float OpenPannelPos = -110;
    public iTween.EaseType CurveType = iTween.EaseType.easeOutQuart;


    private void Awake()
    {
        UpdatePanelPos(HidePannelPos);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanel(float delay)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
                "from", HidePannelPos,
                "to", OpenPannelPos,
                "time", 1f,
                "delay", delay,
                "onupdatetarget", this.gameObject,
                "onupdate", "UpdatePanelPos",
                "oncompletetarget", this.gameObject,
                "oncomplete", "AnimationStoped",
                "easetype", CurveType));
    }

    public void HidePanel()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
                "from", OpenPannelPos,
                "to", HidePannelPos,
                "time", 1f,
                "onupdatetarget", this.gameObject,
                "onupdate", "UpdatePanelPos",
                "oncompletetarget", this.gameObject,
                "oncomplete", "AnimationStoped",
                "easetype", CurveType));
    }

    void UpdatePanelPos(float val)
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(val, gameObject.GetComponent<RectTransform>().anchoredPosition.y);
    }

    void AnimationStoped()
    {

    }
}
