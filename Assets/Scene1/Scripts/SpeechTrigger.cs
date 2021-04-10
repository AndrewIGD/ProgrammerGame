using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechTrigger : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] Transform source;

    bool played = false;
    private void OnTriggerEnter(Collider other)
    {
        if(played == false)
        {
            played = true;

            AudioSource.PlayClipAtPoint(clip, source.position);
        }
    }
}
