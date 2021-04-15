using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideLaser : MonoBehaviour
{
    [SerializeField] float grow;
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x - grow * Time.deltaTime, 100, transform.localScale.x - grow * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<Player>().Death();
    }
}
