using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Capsule : MonoBehaviour
{
    [SerializeField] AudioClip punch;
    [SerializeField] AudioClip close;
    [SerializeField] AudioClip quote;
    [SerializeField] AudioClip tp;
    public void Rise()
    {
        GetComponent<Animator>().Play("in");
        AudioSource.PlayClipAtPoint(punch, Camera.main.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<Animator>().Play("close");
            AudioSource.PlayClipAtPoint(close, Camera.main.transform.position);
            Invoke("Quote", 1.5f);
            Invoke("Canvas", 5f);
            Invoke("NextScene", 9f);
        }
    }

    void Quote()
    {
        AudioSource.PlayClipAtPoint(quote, Camera.main.transform.position);
    }

    void Canvas()
    {
        AudioSource.PlayClipAtPoint(tp, Camera.main.transform.position);
        FindObjectOfType<Canvas>().GetComponent<Animator>().Play("capsule");
    }

    void NextScene()
    {
        PlayerPrefs.SetString("CurrentScene", "Scene3");
        SceneManager.LoadScene("DeathScene");
    }
}
