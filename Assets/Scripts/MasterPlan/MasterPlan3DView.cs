using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterPlan3DView : MonoBehaviour
{
    public CameraMoving CameraMoving;
    public InfoPanel[] InfoPanels;

    public SmallTitleAnim SmallTitle;
    public GameObject WebViewPopup;
    public UniWebView WebView;
    public string[] Urls;

    public Button AmaalaBtn;
    public Button[] LeftBtns;

    bool isInfoPanelOpen = false;
    bool isAnimStoped = true;
    int CurrentTargetIndex = 0;
    private void Awake()
    {
        CameraMoving.MoveToPointComplete.AddListener(() => ResetAnimState());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void MovingCameraToTarget(int targetIndex)
    {
        if (isAnimStoped)
        {
            isAnimStoped = false;
            if (isInfoPanelOpen)
            {
                HidePanel();
            }
            CurrentTargetIndex = targetIndex;
            AmaalaBtn.GetComponent<ShowHideLine>().Hide(0.5f);
            foreach (Button btn in LeftBtns)
            {
                btn.interactable = true;
                btn.gameObject.GetComponent<ShowHideLine>().Hide(0.5f);
            }
            OpenPanel(2f);
            LeftBtns[targetIndex].interactable = false;
            LeftBtns[targetIndex].gameObject.GetComponent<ShowHideLine>().Show(0.5f);
            CameraMoving.MovingCameraToTarget(targetIndex);
        }
    }

    public void MoveCameraToStartPos()
    {
        if (isAnimStoped)
        {
            isAnimStoped = false;
            if (isInfoPanelOpen)
            {
                HidePanel();
            }
            foreach (Button btn in LeftBtns)
            {
                btn.interactable = true;
                btn.gameObject.GetComponent<ShowHideLine>().Hide(0.5f);
            }
            AmaalaBtn.GetComponent<ShowHideLine>().Show(0.5f);
            CameraMoving.BackCameraToStartPos();
        }
    }

    void OpenPanel(float delay)
    {
        isInfoPanelOpen = true;
        InfoPanels[CurrentTargetIndex].OpenPanel(delay);
    }

    void HidePanel()
    {
        isInfoPanelOpen = false;
        InfoPanels[CurrentTargetIndex].HidePanel();
    }

    void ResetAnimState() { isAnimStoped = true; }

    public void ShowWebView(string url)
    {
        WebViewPopup.SetActive(true);
      //  Debug.Log(Urls[CurrentTargetIndex]);
        WebView.Load(url);
        WebView.Show();
    }

    public void CloseWebView()
    {
        WebView.Hide();
        WebViewPopup.SetActive(false);
    }
}
