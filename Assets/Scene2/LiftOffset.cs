using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiftOffset : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GetOffset()
    {
        //offset = GameObject.Find("OVRPlayerController").transform.position - transform.position;
    }

    Vector3 offset;

    private void OnLevelWasLoaded(int level)
    {
        /*if (SceneManager.GetActiveScene().name == "Scene2")
        {
            GameObject.Find("OVRPlayerController").transform.position = GameObject.Find("lift").transform.position + offset;
        }
        else if (SceneManager.GetActiveScene().name != "Scene1")
            Destroy(gameObject);*/
    }
}
