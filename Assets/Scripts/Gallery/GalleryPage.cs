using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryPage : PageBase
{
    //public GameObject MainGalleryObj;
    public GameObject Container;
    public GameObject GalleryItemPrefab;
    public GallerySwiper MainGallerySwiper;

    //public Image AnimateImage;
    //public Sprite[] GalleryImages;
    public GameObject BigGalleryObj;
    public GameObject BigGalleryContainer;
    public GameObject BigGalleryItemPrefab;
    public GallerySwiper BigGallerySwiper;
    public GameObject[] BigGalleryBtns;

    public List<GalleryItem> Images = new List<GalleryItem>();

    public int InitGalleryItems = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init()
    {
        base.Init();
        Images.Clear();
        if (Container) 
        ClearContainer(Container);
        ClearContainer(BigGalleryContainer);
        /*string imagesPath = Application.persistentDataPath + "/Images/";
        if (System.IO.Directory.Exists(imagesPath))
        {
            string[] files = System.IO.Directory.GetFiles(imagesPath);
            foreach (string filePath in files)
            {
                if (CheckFileExtention(filePath))
                {
                    
                }
            }
            if (Images.Count == 0)
            {
                GameManager.instance.ShowInitError("Can't find files...");
            }
        }
        else
        {
            GameManager.instance.ShowInitError("Can't find files...");
        }*/

        BigGalleryObj.GetComponent<FadeInOutAnim>().FadeInEvent.AddListener(() => {
            foreach (GameObject btn in BigGalleryBtns)
            {
                btn.SetActive(true);
            }
        });
        //foreach (Sprite img in GalleryImages)
        //{
        //    GameObject newGalleryItem = Instantiate(GalleryItemPrefab, Container.transform);
        //    newGalleryItem.GetComponent<GalleryItem>().Init(img, this, true);
        //    Images.Add(newGalleryItem.GetComponent<GalleryItem>());

        //    // Init big gallery
        //    GameObject newBigGalleryItem = Instantiate(BigGalleryItemPrefab, BigGalleryContainer.transform);
        //    newBigGalleryItem.GetComponent<GalleryItem>().Init(img, this, false);
        //}
        BigGalleryObj.SetActive(false);
        GameManager.instance.IncrementInitPages();
        Debug.Log("Init GalleryPage");
        
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }

    void ClearContainer(GameObject container)
    {
        for (int i = 0; i < container.transform.childCount; i++)
        {
            Destroy(container.transform.GetChild(i).gameObject);
        }
    }

    /*bool CheckFileExtention(string filePath)
    {
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
        switch (fileInfo.Extension.ToLower())
        {
            case ".jpeg":
            case ".jpg":
            case ".png":
            case ".bmp":
                return true;
            default:
                return false;
        }
    }*/

    public void IncrementInitGalleryItem() {
        InitGalleryItems++;
        CheckInitGalleryItem();
    }

    void CheckInitGalleryItem()
    {
        if (InitGalleryItems == Images.Count)
        {
            
        }
    }


    public void ShowBigGallery()
    {
        //BigGalleryObj.SetActive(true);
        BigGalleryObj.GetComponent<FadeInOutAnim>().FadeIn(0);
        BigGallerySwiper.SetPanelByIndex(MainGallerySwiper.CurrentPanelIndex);
        gameObject.GetComponent<FadeInOutAnim>().FadeOut(0);
    }

    public void CloseBigGallery()
    {
        MainGallerySwiper.SetPanelByIndex(BigGallerySwiper.CurrentPanelIndex);
        //BigGalleryObj.SetActive(false);
        gameObject.GetComponent<FadeInOutAnim>().FadeIn(0);
        foreach (GameObject btn in BigGalleryBtns)
        {
            btn.SetActive(false);
        }
        BigGalleryObj.GetComponent<FadeInOutAnim>().FadeOut(0);
    }
}
