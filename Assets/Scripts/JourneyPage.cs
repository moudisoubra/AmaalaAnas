using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JourneyPage : PageBase
{
    public BrunoMikoski.TextJuicer.TMP_TextJuicer TitleTextJuicer;
    public BrunoMikoski.TextJuicer.TMP_TextJuicer DescTextJuicer;
    public string VideoFileName;
    public Button PlayVideoBtn;
    public Button StopVideoBtn;
    public VideoPlayerController PlayerController;
    
     public AudioSource ad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Show()
    {
        base.Show();
        TitleTextJuicer.Play();
        DescTextJuicer.Play();
    }

    void PlayVideo()
    {
        /*string videoPath = Application.persistentDataPath + "/Videos/" + VideoFileName;
        if (System.IO.File.Exists(videoPath))
        {
            
        }*/
        PlayerController.PlayVideo("");
        ad.Pause();
    }

    void StopVideo()
    {
        PlayerController.StopVideo();
        ad.Play();

    }

    public override void Init()
    {
        base.Init();
        PlayVideoBtn.onClick.AddListener(() => PlayVideo());
        StopVideoBtn.onClick.AddListener(() => StopVideo());

        GameManager.instance.IncrementInitPages();
        Debug.Log("Init JourneyPage");
    }
}
