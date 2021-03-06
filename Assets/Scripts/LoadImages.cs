using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class LoadImages : MonoBehaviour
{

    public string filesLocation = @"C:/images";
    public string videofilesLocation = @"C:/images";
    public List<Texture2D> images = new List<Texture2D>();
    public List<string> videos = new List<string>();
    public VideoPlayer player;
    public List<VideoPlayer> videoPlayers = new List<VideoPlayer>();
    public SpawnImages spawnImg;
    public bool imgsLoaded;
    public bool vidsLoaded;
    public bool activated;

    public LoadImages externalLoad;
    public bool externallyLoaded = false;

    public IEnumerator Start()
    {
        if (!externallyLoaded)
        {

            if (filesLocation != "")
            {
                yield return StartCoroutine(
                    "LoadAll",
                    Directory.GetFiles(filesLocation, "*.png", SearchOption.AllDirectories)
                );
                yield return StartCoroutine(
                    "LoadAll",
                    Directory.GetFiles(filesLocation, "*.jpg", SearchOption.AllDirectories)
                );
                spawnImg.images = images;
                spawnImg.enabled = true;
                imgsLoaded = true;
            }
            if (videofilesLocation != "")
            {

                yield return StartCoroutine(
                    "LoadAllMP4",
                    Directory.GetFiles(videofilesLocation, "*.mp4", SearchOption.AllDirectories)
                );

                vidsLoaded = true;
            }
        }

    }

    public void Update()
    {

    }

    public void DeletePics(Transform content)
    {
        foreach (Transform child in content)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public IEnumerator LoadAll(string[] filePaths)
    {
        foreach (string filePath in filePaths)
        {
            WWW load = new WWW("file:///" + filePath);
            yield return load;
            if (!string.IsNullOrEmpty(load.error))
            {
                Debug.LogWarning(filePath + " error");
            }
            else
            {
                images.Add(load.texture);
            }
        }
    }

    public IEnumerator LoadAllMP4(string[] filePaths)
    {
        foreach (string filePath in filePaths)
        {
            WWW load = new WWW("file:///" + filePath);
            yield return load;
            if (!string.IsNullOrEmpty(load.error))
            {
                Debug.LogWarning(filePath + " error");
            }
            else
            {
                videos.Add(filePath);
            }
        }
    }
}