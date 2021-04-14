using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCamera : MonoBehaviour
{
    void Update()
    {
        GetComponent<Camera>().enabled = false;

        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
}
