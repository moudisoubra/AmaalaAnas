using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GallerySwiper : MonoBehaviour,IDragHandler, IEndDragHandler
{
    public float StartLocation;
    private Vector3 ContentLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int CurrentPanelIndex = 0;
    public float Step = 1875;


    bool CanSwipe = true;

    private void Awake()
    {
        StartLocation = transform.position.x;
        ContentLocation = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CanSwipe)
        {
            float difference = eventData.pressPosition.x - eventData.position.x;
            transform.position = ContentLocation - new Vector3(difference, 0, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (CanSwipe)
        {
            float percentage = (eventData.pressPosition.x - eventData.position.x) / Step;

            if (Mathf.Abs(percentage) >= percentThreshold)
            {
                if (percentage > 0)
                {
                    SetNextPanel();
                }
                else if (percentage < 0)
                {
                    SetPrevPanel();
                }
            }
            else
            {
                StartCoroutine(SmoothMove(transform.position, ContentLocation, easing));
            }
        }
    }

    IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float seconds)
    {
        float t = 0;
        CanSwipe = false;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
        CanSwipe = true;
    }

    public void SetNextPanel()
    {
        if (CanSwipe)
        {
            float xRectSize = GetComponent<RectTransform>().sizeDelta.x;
            float xRectPos = GetComponent<RectTransform>().anchoredPosition.x;
            Vector3 newLocation = ContentLocation;
            if ((xRectPos - Step) > -xRectSize)
            {
                newLocation += new Vector3(-Step, 0, 0);
                if (CurrentPanelIndex + 1 < transform.childCount) { CurrentPanelIndex++; }
                ContentLocation = newLocation;
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
        }
    }

    public void SetPrevPanel()
    {
        if (CanSwipe)
        {
            float xRectPos = GetComponent<RectTransform>().anchoredPosition.x;
            Vector3 newLocation = ContentLocation;
            if (xRectPos < 0)
            {
                newLocation += new Vector3(Step, 0, 0);
                if (CurrentPanelIndex - 1 >= 0) { CurrentPanelIndex--; }
                ContentLocation = newLocation;
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
        }
        
    }

    public void SetPanelByIndex(int index)
    {
        if (index >= 0 && index < transform.childCount)
        {
            StopAllCoroutines();
            CurrentPanelIndex = index;
            float newPos = index * Step;
            Vector3 newLocation = new Vector3(StartLocation - newPos, transform.position.y, transform.position.z);
            transform.position = newLocation;
            ContentLocation = newLocation;
        }
    }
}
