using UnityEngine;
using System.Collections;

public class ScreenInput : MonoBehaviour
{
    public delegate void onPressedDelegate(Collider _colider);
    public event onPressedDelegate OnPressed;

    [SerializeField]
    private LayerMask layerMask;

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

                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
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
    }
}
