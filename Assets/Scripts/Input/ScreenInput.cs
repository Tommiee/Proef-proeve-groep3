using UnityEngine;
using System.Collections;

public class ScreenInput : MonoBehaviour
{
    public delegate Collider onPressedDelegate(Collider _colider);
    public event onPressedDelegate OnPressed;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    // Construct a ray from the current touch coordinates
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                    RaycastHit hit;

                    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.white, 3.0f);

                    if (Physics.Raycast(ray, out hit))
                    {
                        PressedOnObject(hit.collider);
                    }
                }
            }
        }
    }

    private void PressedOnObject(Collider _col)
    {
        OnPressed?.Invoke(_col);
        print(_col);
    }
}
