using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterPlanPage : PageBase
{

    public GameObject MainMenu;
    public GameObject MasterPlan3D;
    public ScrollRect ScrollRect;
    public ContentItemAnim[] Contents;

    public float scrollPosition = 0;

    bool showLastContentItems = false;
    bool Show3DMasterPlan = false;
    public GameObject waves;
    public bool firstIteration = true;
    public bool secondIteration = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scrollPosition = Mathf.Clamp01(ScrollRect.verticalNormalizedPosition) * 100;
        if (firstIteration && scrollPosition < 75)
        {
            //showLastContentItems = true;
            Contents[2].ShowContent();
            Contents[3].ShowContent();
            Debug.Log("first");
            firstIteration = false;

        }
        if (secondIteration && scrollPosition < 40)
        {
            Contents[4].ShowContent();
            Contents[5].ShowContent();
            Debug.Log("second");
            secondIteration = false;

        }

        //Debug.Log("verticalNormalizedPosition: " + scrollPosition);
    }

    public override void Init()
    {
        base.Init();
        showLastContentItems = false;
        GameManager.instance.IncrementInitPages();
        Debug.Log("Init MasterPlanPage");
    }

    public override void Show()
    {
        base.Show();
        showLastContentItems = false;
        Contents[0].HideContent();
        Contents[1].HideContent();
        Contents[2].HideContent();
        Contents[3].HideContent();

        Contents[0].ShowContent();
        Contents[1].ShowContent();
    }

    public override void Hide()
    {
        base.Hide();
        if (Show3DMasterPlan)
        {
            MasterPlan3D.GetComponent<FadeInOutAnim>().FadeOut(0);
            MainMenu.GetComponent<FadeInOutAnim>().FadeIn(0);
            Show3DMasterPlan = false;
            waves.gameObject.SetActive(false);

        }
    }

    public void OpenMasterPlan3D(bool val)
    {
        Show3DMasterPlan = val;
        if (val)
        {
            MainMenu.GetComponent<FadeInOutAnim>().FadeOut(0);
            gameObject.GetComponent<FadeInOutAnim>().FadeOut(0);
            MasterPlan3D.GetComponent<FadeInOutAnim>().FadeIn(0.5f);
            MasterPlan3D.GetComponent<MasterPlan3DView>().MoveCameraToStartPos();
            waves.gameObject.SetActive(true);
        }
        else
        {
            MainMenu.GetComponent<FadeInOutAnim>().FadeIn(0);
            gameObject.GetComponent<FadeInOutAnim>().FadeIn(0);
            MasterPlan3D.GetComponent<FadeInOutAnim>().FadeOut(0);
            waves.gameObject.SetActive(false);

        }
    }
}