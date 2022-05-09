using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoURL : MonoBehaviour
{
    public string url;
    public string nameOfVideo;
    public VideoPlayer player;
    public LoadImages liScript;

    public bool animated;
    public bool play;
    void Start()
    {
        SetVideo();
    }

    void Update()
    {
        if (url == "")
        {
            SetVideo();
        }

        if(player != null && !player.isPlaying && url != "" && play)
        {
            PlayVideo();
            play = false;
        }

    }
    public void SetPlay(bool b)
    {
        play = b;
    }
    void CheckDimensions(string url)
    {
        player.source = VideoSource.Url;
        player.url = url;
        player.prepareCompleted += (VideoPlayer source) =>
        {
            Debug.Log("dimensions " + source.texture.width + " x " + source.texture.height); // do with these dimensions as you wish
            //Destroy(tempVideo);
            RenderTexture rt = new RenderTexture(source.texture.width, source.texture.height, 0);
            rt.name = transform.gameObject.name;
            player.targetTexture = rt;
            player.GetComponent<RawImage>().texture = rt;
            player.GetComponent<RawImage>().color = Color.white;

        };
        player.gameObject.SetActive(true);
        player.Prepare();
    }
    public void SetVideo()
    {
        if (liScript != null)
        {
            for (int i = 0; i < liScript.videos.Count; i++)
            {
                if (liScript.videos[i].Contains(nameOfVideo))
                {
                    url = liScript.videos[i];
                    //CheckDimensions(url);
                }
            }
        }
        //player.url = url;
        //player.gameObject.SetActive(true);
        //player.Play();
    }

    public void PlayVideo()
    {
        if (url != "")
        {
            CheckDimensions(url);

            player.url = url;
            player.Play();

            player.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Video Null");
        }
    }
}
