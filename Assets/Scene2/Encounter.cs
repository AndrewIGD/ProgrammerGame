using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    [SerializeField] NPC npc;
    [SerializeField] AudioSource[] conversation;
    [SerializeField] Scene2Event sceneEvent;
    [SerializeField] bool playEncounter = true;
    [SerializeField] GameObject lookAt;
    [SerializeField] GameObject blocker;
    int index = 0;
    bool hasEncountered = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && hasEncountered == false)
        {
            hasEncountered = true;
            if (playEncounter)
                npc.BeginEncounter();

            if (blocker != null)
                blocker.SetActive(true);

            Invoke("Conversation", 1f);
        }
    }

    [SerializeField] NPC otherNpc;
    [SerializeField] Conversation convo;
    void Conversation()
    {
        if(index == conversation.Length)
        {
            switch(sceneEvent)
            {
                case Scene2Event.GoCubicle:
                    {
                        npc.GetComponent<Animator>().Play("cubicle");
                        npc.NotWatch(lookAt);
                        break;
                    }
                case Scene2Event.HackAnnounce:
                    {
                        npc.GetComponent<Animator>().Play("panic");
                        Invoke("OtherNpc", 4f);
                        break;
                    }
                case Scene2Event.OtherAnnounce:
                    {
                        otherNpc.GetComponent<Animator>().Play("announce");
                        convo.Begin();
                        break;
                    }
            }
        }
        else {
            conversation[index].Play();
            Invoke("Conversation", conversation[index++].clip.length);
        }
    }

    void OtherNpc()
    {
        otherNpc.SetRoot(-90);
        otherNpc.GetComponent<Animator>().Play("announce");
        convo.Begin();
    }
}

public enum Scene2Event
{
    GoCubicle,
    HackAnnounce,
    BossHeadUp,
    OtherAnnounce,
    BossCome,
    ScreenTurn,
    ComputerExplode,
    Shutdown,
    GoCapsule,
    FistWall,
    CapsuleClose
}
