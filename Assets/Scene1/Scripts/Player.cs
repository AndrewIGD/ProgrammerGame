using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;

    Animator animator;
    CapsuleCollider capsuleCollider;
    CharacterController characterController;
    private void Start()
    {
        animator = GetComponent<Animator>();

        //capsuleCollider = GetComponent<CapsuleCollider>();
        //characterController = GetComponent<CharacterController>();

        PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
    }
    public void Death()
    {
        deathSound.Play();
        animator.Play("death");
    }

    public void DeathScene()
    {
        FindObjectOfType<Canvas>().GetComponent<Animator>().Play("exit");
    }

    private void Update()
    {
        //capsuleCollider.height = characterController.height;
    }
}
