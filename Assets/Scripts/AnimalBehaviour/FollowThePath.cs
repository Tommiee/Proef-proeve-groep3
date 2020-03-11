using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    [SerializeField]
    private Waypoint waypointPrefab;

    [SerializeField]
    private List<Waypoint> waypoints = new List<Waypoint>();

    private Waypoint currentTarget;

    [SerializeField]
    private float moveSpeed = 2f;
    private int waypointIndex = 0;

    private void Awake()
    {
        waypoints = new List<Waypoint>(transform.GetComponentsInChildren<Waypoint>());
        waypoints.Add(CreateWaypoint());
        currentTarget = waypoints[waypointIndex];
        currentTarget.OnCollide(() => NextPoint());
        transform.DetachChildren();
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
    }

    private void NextPoint()
    {
        waypointIndex += 1;
        if (waypointIndex >= waypoints.Count) waypointIndex = 0;
        currentTarget = waypoints[waypointIndex];
        currentTarget.OnCollide(() =>
        {
            NextPoint();
        });
        Debug.Log("Next point " + waypointIndex);
    }

    public Waypoint CreateWaypoint()
    {
        Waypoint waypoint = Instantiate(waypointPrefab, transform);
        waypoint.name = gameObject.name + "Waypoint";
        return waypoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Waypoint[] childWaypoints = (waypoints.Count > 0)? waypoints.ToArray() : transform.GetComponentsInChildren<Waypoint>();

        for (int i = 0; i < childWaypoints.Length; i++)
        {
            Waypoint currentWaypoint = childWaypoints[i];
            Waypoint nextWaypoint = (i + 1 < childWaypoints.Length) ? childWaypoints[i + 1] : childWaypoints[0];
            Gizmos.DrawLine(currentWaypoint.position, nextWaypoint.position);
        }
    }
}
