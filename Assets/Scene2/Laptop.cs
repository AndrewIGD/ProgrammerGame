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
    [SerializeField] AudioSource errorSound;
    [SerializeField] Conversation conversation;
    [SerializeField] GameObject screen;
    [SerializeField] Material mat;
    public bool error = false;
    int errorIndex = 1;
    int index = 0;

    public void Error()
    {
        screen.GetComponent<Renderer>().material = mat;
        error = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Contains("Hand"))
        {
            if (error)
            {
                keyPress.Play();
                errorSound.Play();

                errorIndex++;

                if(errorIndex == 6)
                {
                    conversation.Begin();
                }
            }
            else
            {
                screen.GetComponent<Renderer>().material = screens[index++];
                keyPress.Play();

                if (index == screens.Length)
                {
                    sound.Play();
                    particles.Play();
                    Invoke("PlayNpc", 1f);
                    enabled = false;
                }
            }
        }
    }

    [SerializeField] AudioSource npcFeedback;
    void PlayNpc()
    {
        npcFeedback.Play();
    }
}
