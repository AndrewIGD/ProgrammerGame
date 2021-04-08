using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Car : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    AIDestinationSetter destinationSetter;

    private void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().Death();
        }
    }

    private void Update()
    {
        if (destinationSetter.target != null)
        {
            if(Vector3.Distance(transform.position, destinationSetter.target.position) < 1)
            {
                destinationSetter.target = waypoints[Random.Range(1, 999999) % waypoints.Count];
            }
        }
        else destinationSetter.target = waypoints[Random.Range(1, 999999) % waypoints.Count];
    }
}
