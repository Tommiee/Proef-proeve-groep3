using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Waypoint : MonoBehaviour
{
    protected Action onCollide;
    protected SphereCollider sphereCollider;
    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
        onCollide += () => Debug.Log("Collided");
    }

    public Vector3 position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }

    public void OnCollide(Action action)
    {
        onCollide += action;
    }

    private void OnTriggerEnter(Collider other)
    {
        onCollide.Invoke();
        onCollide = () => Debug.Log("Collided");
    }
}
