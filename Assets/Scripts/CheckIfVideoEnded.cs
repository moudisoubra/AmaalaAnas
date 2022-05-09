using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CheckIfVideoEnded : MonoBehaviour
{
    public FadeInOutAnim anim;
    public VideoPlayer player;
    public long count;
    public long currentFrame;
    public bool finished;
    public bool started;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count = (long)player.frameCount;
        currentFrame = player.frame;

        if (currentFrame == count - 1 && currentFrame > 100 && started)
        {
            Debug.Log("Video Finished");
            finished = true;
            started = false;
        }

        if (finished)
        {
            anim.FadeOut(0.1f);
            finished = false;
        }
    }

    public void SetStarted()
    {
        started = true;
    }
}
