using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] AudioSource successSound;
    public void BeginEncounter()
    {
        GetComponent<Animator>().Play("encounter");
        GetComponent<AudioSource>().Play();
    }

    public void WatchTarget()
    {
        watchTarget = true;
    }

    public void SuccessSound()
    {
        successSound.Play();
        watchTarget = false;
    }

    bool watchTarget = false;
    private void Update()
    {
        if(true)
        {
            transform.LookAt(target.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
