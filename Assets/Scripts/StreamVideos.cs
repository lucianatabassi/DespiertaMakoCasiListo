using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StreamVideos : MonoBehaviour
{
    public int escena;

    [SerializeField]
    private VideoPlayer video;

    [SerializeField]
    private string videoFileName;
    void Start()
    {
        video.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        Debug.Log(video.url);
        video.Play();
        video.loopPointReached += CheckOver;
    }


    void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene(escena);
    }
    
}