using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] Material flipNormalsMaterial;
    [SerializeField] Renderer renderer;

    private void Start()
    {
        videoPlayer.loopPointReached += ResetScene;
    }

    private void ResetScene(VideoPlayer source)
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene", "Scene1"));
    }

    bool changed = false;

    private void Update()
    {
        if(videoPlayer.isPlaying && changed == false)
        {
            changed = true;
            renderer.material = flipNormalsMaterial;
        }
    }
}
