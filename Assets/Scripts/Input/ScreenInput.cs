﻿using UnityEngine;
using System.Collections;

public class ScreenInput : MonoBehaviour
{
    public GameObject particle;
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                // Create a particle if hit
                if (Physics.Raycast(ray))
                {
                    PressedOnObject();
                }
            }
        }
    }

    private void PressedOnObject()
    {
        Instantiate(particle, transform.position, transform.rotation);
    }
}
