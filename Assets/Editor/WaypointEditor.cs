using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FollowThePath))]
public class WaypointEditor : Editor{


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FollowThePath waypointManager = (FollowThePath)target;
        if (GUILayout.Button("Create Waypoint")) {
            waypointManager.CreateWaypoint();
        }
    }
}
