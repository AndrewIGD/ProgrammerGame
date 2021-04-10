using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftOpener : MonoBehaviour
{
    [SerializeField] Animator liftAnimator;
    [SerializeField] AudioSource elevatorSound;

    private void Start()
    {
        Invoke("Open", 4f);
    }

    void Open()
    {
        liftAnimator.enabled = true;
        elevatorSound.Play();
    }
}
