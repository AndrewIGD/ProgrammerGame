using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            door.SetActive(true);
            gameObject.SetActive(false);
        }    
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 90 * Time.deltaTime, 0));
    }
}
