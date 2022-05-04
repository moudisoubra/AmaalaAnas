using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowUIToObject : MonoBehaviour
{

    public Camera Cam;
    public Transform TargetObj;

    RectTransform RctTransform;

    private void Awake()
    {
        RctTransform = GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetObj && Cam)
        {
            Vector3 screenPos = Cam.WorldToScreenPoint(TargetObj.position);
            //Debug.Log("target is " + screenPos.x + " pixels from the left");
            RctTransform.anchoredPosition = new Vector2(screenPos.x, screenPos.y);
        }
    }
}
