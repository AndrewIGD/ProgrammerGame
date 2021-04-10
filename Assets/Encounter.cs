using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    [SerializeField] NPC npc;
    [SerializeField] AudioSource[] conversation;
    [SerializeField] Scene2Event sceneEvent;
    [SerializeField] bool playEncounter = true;
    int index = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (playEncounter)
                npc.BeginEncounter();
            Invoke("Conversation", 1f);
        }
    }

    [SerializeField] NPC otherNpc;
    [SerializeField] Conversation conversation;
    void Conversation()
    {
        if(index == conversation.Length)
        {
            switch(sceneEvent)
            {
                case Scene2Event.GoCubicle:
                    {
                        npc.GetComponent<Animator>().Play("cubicle");
                        break;
                    }
                case Scene2Event.HackAnnounce:
                    {
                        otherNpc.GetComponent<Animator>().Play("hackAnnounce");
                        conversation.Begin();
                        break;
                    }
            }
        }
        else {
            conversation[index].Play();
            Invoke("Conversation", conversation[index++].clip.length);
        }
    }
}

public enum Scene2Event
{
    GoCubicle,
    HackAnnounce
}
