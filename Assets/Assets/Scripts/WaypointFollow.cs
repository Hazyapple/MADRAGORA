using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint1Index = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypoint1Index].transform.position, transform.position) < .1f)
        {
            currentWaypoint1Index++;
            if (currentWaypoint1Index >= waypoints.Length)
            {
                currentWaypoint1Index = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint1Index].transform.position, Time.deltaTime * speed);
    }
}
