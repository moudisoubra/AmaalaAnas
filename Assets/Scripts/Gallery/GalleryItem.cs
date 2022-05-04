using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GalleryItem : MonoBehaviour
{
    GalleryPage Owner;
    //RawImage ItemImage;
    Image ItemImage;
    AspectRatioFitter AspectRatioFitter;
    Button Btn;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void Init(string filePath, GalleryPage owner)
    {
        AspectRatioFitter = GetComponent<AspectRatioFitter>();
        //ItemImage = GetComponent<RawImage>();
        ItemImage = GetComponent<Image>();
        Btn = GetComponent<Button>();
        Owner = owner;
        if (ItemImage && AspectRatioFitter)
        {
            StartCoroutine(CreateSpriteForImageConponent(filePath));
        }
        if (Btn)
        {
            Btn.onClick.AddListener(() => { Owner.ShowBigGallery(); });
        }
    }*/

    public void Init(Sprite sprite, GalleryPage owner, bool initBtn)
    {
        AspectRatioFitter = GetComponent<AspectRatioFitter>();
        ItemImage = GetComponent<Image>();
        Owner = owner;
        if (ItemImage && AspectRatioFitter)
        {
            ItemImage.sprite = sprite;
            AspectRatioFitter.aspectRatio = (float)sprite.texture.width / (float)sprite.texture.height;
        }
        if (initBtn)
        {
            Btn = GetComponent<Button>();
            if (Btn)
            {
                Btn.onClick.AddListener(() => { Owner.ShowBigGallery(); });
            }
        }
    }


    /*IEnumerator CreateSpriteForImageConponent(string _fileUrl)
    {
#if UNITY_ANDROID || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        _fileUrl = "file://" + _fileUrl;
#endif
        UnityWebRequest UploadRequest = UnityWebRequestTexture.GetTexture(_fileUrl);
        yield return UploadRequest.SendWebRequest();

        if (UploadRequest.isNetworkError || UploadRequest.isHttpError)
        {
            Debug.Log(UploadRequest.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)UploadRequest.downloadHandler).texture;
            if (texture != null)
            {
                //Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
                //ItemImage.sprite = sprite;
                //ItemImage.preserveAspect = true;
                ItemImage.texture = texture;
                AspectRatioFitter.aspectRatio = (float)texture.width / (float)texture.height;
                Owner.IncrementInitGalleryItem();
            }
        }
    }*/

    //public Sprite GetImageTexture() { return ItemImage.texture; }
}
