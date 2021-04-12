using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    [SerializeField] AudioSource[] conversation;
    [SerializeField] Scene2Event sceneEvent;
    [SerializeField] Conversation convo;
    [SerializeField] NPC targetNpc;
    [SerializeField] NPC otherNpc;
    [SerializeField] MeshRenderer[] tvs;
    [SerializeField] MeshRenderer[] desktops;
    [SerializeField] Material computerMat;
    [SerializeField] GameObject computer;
    [SerializeField] GameObject particles;
    [SerializeField] bool begin = false;
    [SerializeField] GameObject laptop;
    [SerializeField] GameObject[] otherLaptops;
    [SerializeField] NPC[] npcs;
    [SerializeField] GameObject[] teleport;
    [SerializeField] GameObject blocker;

    private void Start()
    {
        if (begin)
            Begin();
    }

    public void Begin()
    {
        Invoke("Convo", 1f);
    }
    int index = 0;

    void Convo()
    {
        if (index == conversation.Length)
        {
            switch (sceneEvent)
            {
                case Scene2Event.BossHeadUp:
                    {
                        targetNpc.NotWatch(otherNpc.gameObject);
                        targetNpc.GetComponent<Animator>().Play("headUp");
                        convo.Begin();
                        break;
                    }
                case Scene2Event.OtherAnnounce:
                    {
                        targetNpc.SetRoot(-90);
                        targetNpc.GetComponent<Animator>().Play("announce");
                        convo.Begin();
                        break;
                    }
                case Scene2Event.BossCome:
                    {
                        foreach (NPC npc in npcs)
                            npc.GetComponent<Animator>().Play("stopAnnounce");

                        Invoke("StopAnnounce", 1f);

                        laptop.GetComponent<Laptop>().Error();
                        foreach (GameObject laptop in otherLaptops)
                            laptop.SetActive(false);
                        targetNpc.GetComponent<Animator>().Play("bossCome");

                        blocker.SetActive(false);

                        break;
                    }
                case Scene2Event.ScreenTurn:
                    {
                        foreach (MeshRenderer tv in tvs)
                            tv.materials[1] = computerMat;
                        foreach (MeshRenderer desktop in desktops)
                            desktop.materials[2] = computerMat;
                        convo.Begin();
                        break;
                    }
                case Scene2Event.ComputerExplode:
                    {
                        computer.SetActive(false);
                        particles.SetActive(true);
                        convo.Begin();
                        break;
                    }
            }
        }
        else
        {
            conversation[index].Play();
            Invoke("Convo", conversation[index++].clip.length);
        }
    }

    void StopAnnounce()
    {
        for (int i = 0; i < npcs.Length; i++)
        {
            npcs[i].GetComponent<Animator>().Play("computer");
        }
    }
}
