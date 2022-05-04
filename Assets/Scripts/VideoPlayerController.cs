using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public AspectRatioFitter aspectRatio;
    public GameObject CloseBtn;
    public RawImage VideoPlayerVideo;
    //RenderTexture VideoTexture;
    FadeInOutAnim FadeInOutAnimController;

    private void Awake()
    {
        if (videoPlayer)
        {
            videoPlayer.prepareCompleted += VideoPlayer_prepareCompleted;
            
            VideoPlayerVideo.texture = videoPlayer.texture;
            gameObject.GetComponent<FadeInOutAnim>().FadeInEvent.AddListener(() => {
                CloseBtn.SetActive(true);
            });
        }
    }

    private void VideoPlayer_prepareCompleted(VideoPlayer source)
    {
    //    aspectRatio.aspectRatio = (float)source.targetTexture.width / (float)source.targetTexture.height;
        source.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo(string videoPath)
    {
        //gameObject.SetActive(true);
        if (!FadeInOutAnimController)
        {
            FadeInOutAnimController = GetComponent<FadeInOutAnim>();
        }
        FadeInOutAnimController.FadeIn(0);
        //VideoTexture.Release();
        //videoPlayer.url = videoPath;
        videoPlayer.Prepare();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
        //gameObject.SetActive(false);
        CloseBtn.SetActive(false);
        FadeInOutAnimController.FadeOut(0);
    }
}
