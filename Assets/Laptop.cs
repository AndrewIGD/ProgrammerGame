using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    [SerializeField] MeshRenderer laptopScreen;
    [SerializeField] Material[] screens;
    [SerializeField] AudioSource keyPress;
    [SerializeField] AudioSource sound;
    [SerializeField] ParticleSystem particles;
    [SerializeField] NPC npc;
    int index = 1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Contains("Hand"))
        {
            laptopScreen.materials[2] = screens[index++];
            keyPress.Play();

            if(index == screens.Length)
            {
                sound.Play();
                particles.Play();
                enabled = false;
            }
        }
    }
}
