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
        if (other.tag == "Hand")
        {
            animator.Play("press");
            press.Play();
            Invoke("CloseLift", 1f);
            Invoke("NextScene", 10f);
        }
    }

    void CloseLift()
    {
        lift.Play();
        doorLift.Play("doorClose");
    }

    void NextScene()
    {
        SceneManager.LoadScene("Scene2");
    }
}
