using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Collider player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = other;
            Invoke("KillPlayer", 1.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == player)
            player = null;
    }

    void KillPlayer()
    {
        if (player != null)
            player.GetComponent<Player>().Death();
    }
}
