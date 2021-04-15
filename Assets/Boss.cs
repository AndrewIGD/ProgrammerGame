using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject laser;
    bool lookPlayer = false;
    void Update()
    {
        if (lookPlayer)
        {

        }
        else
        {
            transform.Rotate(0, 15 * Time.deltaTime, 0);

            Vector3 oldEuler = transform.eulerAngles;

            transform.LookAt(target.transform);

            if (Mathf.Abs(oldEuler.y - transform.eulerAngles.y) < 15)
            {
                laser.SetActive(true);
                lookPlayer = true;
            }

            transform.eulerAngles = oldEuler;
        }
    }
}
