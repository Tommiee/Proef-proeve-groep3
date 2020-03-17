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

    [SerializeField]
    private Vector2 waypointSpawnOffset;

    [SerializeField]
    private Color gizmoColor = Color.green;

    private void Awake()
    {
        waypoints = new List<Waypoint>(transform.GetComponentsInChildren<Waypoint>());
        currentTarget = waypoints[waypointIndex];
        currentTarget.OnCollide(() => NextPoint());
        transform.DetachChildren();
    }


    private void Update()
    {
        Move();
    }

    public void Move()
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
        Debug.Log("Next point " + currentTarget.name);
    }

    public Waypoint CreateWaypoint()
    {
        Waypoint waypoint = Instantiate(waypointPrefab, transform);
        waypoint.name = gameObject.name + "Waypoint" + transform.childCount;
        waypoint.position = new Vector3( waypointSpawnOffset.x, transform.position.y, waypointSpawnOffset.y);
        waypoint.color = gizmoColor;
        return waypoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Waypoint[] childWaypoints = (waypoints.Count > 0)? waypoints.ToArray() : transform.GetComponentsInChildren<Waypoint>();

        for (int i = 0; i < childWaypoints.Length; i++)
        {
            Waypoint currentWaypoint = childWaypoints[i];
            Waypoint nextWaypoint = (i + 1 < childWaypoints.Length) ? childWaypoints[i + 1] : childWaypoints[0];
            currentWaypoint.color = gizmoColor;
            Gizmos.DrawLine(currentWaypoint.position, nextWaypoint.position);
        }

        if (!currentTarget) return;
        currentTarget.color = new Color(1.0f - gizmoColor.r, 1.0f - gizmoColor.g, 1.0f - gizmoColor.b);
    }
}
