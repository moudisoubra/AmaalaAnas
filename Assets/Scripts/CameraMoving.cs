using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMoving : MonoBehaviour
{
    public Transform[] Targets;
    public float EndYDistance = 1;
    public float EndZDistance = -1;
    public iTween.EaseType CurveType = iTween.EaseType.easeOutQuart;
    public UnityEvent MoveToPointComplete;
    public UnityEvent MoveToStartPosComplete;
    Vector3 StartPos;
    Vector3 CurrentPos;


    bool CanMove = true;
    private void Awake()
    {
        StartPos = transform.position;
        CurrentPos = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MovingCameraToTarget(int targetIndex)
    {
        if (CanMove)
        {
            CanMove = false;
            Targets[targetIndex].TransformPoint(Vector3.zero);
            iTween.ValueTo(gameObject, iTween.Hash(
                "from", CurrentPos,
                "to", new Vector3(Targets[targetIndex].position.x, Targets[targetIndex].position.y + EndYDistance, Targets[targetIndex].position.z + EndZDistance),
                "time", 3f,
                "onupdatetarget", this.gameObject,
                "onupdate", "UpdateAlpha",
                "oncompletetarget", this.gameObject,
                "oncomplete", "CameraStoped",
                "easetype", CurveType));
        }
    }

    public void BackCameraToStartPos()
    {
        if (CanMove)
        {
            CanMove = false;
            iTween.ValueTo(gameObject, iTween.Hash(
                "from", CurrentPos,
                "to", StartPos,
                "time", 3f,
                "onupdatetarget", this.gameObject,
                "onupdate", "UpdateAlpha",
                "oncompletetarget", this.gameObject,
                "oncomplete", "CameraStoped",
                "easetype", CurveType));
        }
    }

    void UpdateAlpha(Vector3 newPos)
    {
        transform.position = newPos;
    }

    void CameraStoped()
    {
        CurrentPos = transform.position;
        CanMove = true;
        MoveToPointComplete.Invoke();
    }
}
