using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    static public GameManager instance = null;

    public int CurrentPage = -1;
    public PageBase[] Pages;
    public int InitPagesCount = 0;
    public GameObject CustomLoadScreen;
    public TMP_Text ErrorTextField;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EnablePages(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPageByIndex(int index)
    {
        if (index > -1 && index < Pages.Length)
        {
            CurrentPage = index;
            Pages[CurrentPage].Show();
        }
    }

    public void HideCurrentPage()
    {
        Pages[CurrentPage].Hide();
        CurrentPage = -1;
    }

    public void IncrementInitPages()
    {
        InitPagesCount++;
        CheckInitPages();
    }

    void CheckInitPages()
    {
        if (InitPagesCount == Pages.Length)
        {
            EnablePages(false);
            CustomLoadScreen.SetActive(false);
        }
    }

    void EnablePages(bool val)
    {
        foreach (PageBase page in Pages)
        {
            page.gameObject.SetActive(val);
        }
    }

    public void ShowInitError(string error)
    {
        ErrorTextField.text = error;
        Loom.QueueOnMainThread(() => {
            EnablePages(false);
            CustomLoadScreen.SetActive(false);
        }, 5f);
    }
}
