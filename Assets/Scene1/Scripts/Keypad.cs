using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keypad : MonoBehaviour
{
    [SerializeField] Animator doorLift;
    [SerializeField] AudioSource press;
    [SerializeField] AudioSource lift;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Hand"))
        {
            if (other.tag.Contains("Left") //&&

                 //(OVRInput.Get(OVRInput.Touch.One) || OVRInput.Get(OVRInput.Touch.Two) || OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || OVRInput.Get(OVRInput.Touch.SecondaryThumbRest)//Daca e pe unul din butoane sau pe joystick
                 //)

                 //&& OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.9f //Si apas pe trigger

                 // && OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger) == false //Si nu apas pe index trigger

                 )
            {
                animator.Play("press");
                press.Play();
                Invoke("CloseLift", 1f);
                Invoke("NextScene", 10f);
            }
            else if (other.tag.Contains("Right") //&&

                 //(OVRInput.Get(OVRInput.Touch.Three) || OVRInput.Get(OVRInput.Touch.Four) || OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || OVRInput.Get(OVRInput.Touch.PrimaryThumbRest)//Daca e pe unul din butoane sau pe joystick
                 //)

                 //&& OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.9f //Si apas pe trigger

                 //&& OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger) == false //Si nu apas pe index trigger

                 )
            {
                animator.Play("press");
                press.Play();
                Invoke("CloseLift", 1f);
                Invoke("NextScene", 10f);
            }
        }
    }

    void CloseLift()
    {
        lift.Play();
        doorLift.Play("doorClose");
        Invoke("Dim", 3f);
    }

    void Dim()
    {
        GameObject.Find("Lights").GetComponent<Animator>().Play("dim");
    }

    void NextScene()
    {
        FindObjectOfType<LiftOffset>().GetOffset();
        SceneManager.LoadScene("Scene2");
    }
}
