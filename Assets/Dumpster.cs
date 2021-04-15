using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] AudioClip impact;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cube")
        {
            Destroy(other.gameObject);
            portal.SetActive(true);
            AudioSource.PlayClipAtPoint(impact, transform.position, 0.4f);
        }
    }
}
